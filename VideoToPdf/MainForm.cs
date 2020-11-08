using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iText.IO.Image;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using Path = System.IO.Path;

namespace VideoToPdf
{
    public partial class MainForm : Form
    {
        private readonly BindingList<string> _selectedFiles = new BindingList<string>();

        public MainForm()
        {
            InitializeComponent();
            FilesListBox.DataSource = _selectedFiles;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (AddVideoOpenFileDialog.ShowDialog(this) == DialogResult.OK)
                AddVideoFile(AddVideoOpenFileDialog.FileName);
        }

        private void AddVideoFile(string path)
        {
            if (_selectedFiles.Contains(path))
            {
                MessageBox.Show(this, "The file was already added.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            _selectedFiles.Add(path);
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            var selectedItem = (string) FilesListBox.SelectedItem;
            _selectedFiles.Remove(selectedItem);
        }

        private void FilesListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            RemoveButton.Enabled = FilesListBox.SelectedIndex > -1;
            MoveDownButton.Enabled = FilesListBox.SelectedIndex > -1;
            MoveUpButton.Enabled = FilesListBox.SelectedIndex > -1;
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            if (FilesListBox.SelectedIndex == 0) return;

            var newIndex = FilesListBox.SelectedIndex - 1;

            var item = (string) FilesListBox.SelectedItem;
            _selectedFiles.RemoveAt(FilesListBox.SelectedIndex);
            _selectedFiles.Insert(newIndex, item);

            FilesListBox.SelectedIndex = newIndex;
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            if (FilesListBox.SelectedIndex == _selectedFiles.Count - 1) return;

            var newIndex = FilesListBox.SelectedIndex + 1;

            var item = (string) FilesListBox.SelectedItem;
            _selectedFiles.RemoveAt(FilesListBox.SelectedIndex);
            _selectedFiles.Insert(newIndex, item);

            FilesListBox.SelectedIndex = newIndex;
        }

        private void FilesListBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Move;
        }

        private void FilesListBox_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            foreach (var file in files) AddVideoFile(file);
        }

        private async void CreateButton_Click(object sender, EventArgs e)
        {
            if (!_selectedFiles.Any())
            {
                MessageBox.Show(this, "No files selected. Please add the video files first.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var ffmegFile = new FileInfo("./ffmpeg.exe");
            if (!ffmegFile.Exists)
                MessageBox.Show(this,
                    "Please make sure that ffmpeg.exe is in the working directory of this software. Maybe download again.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            var utils = new FfmpegUtils(ffmegFile.FullName);
            var tmpDirectory =
                new DirectoryInfo(Path.Combine(Path.GetTempPath(), "VideoToPdf_" + Guid.NewGuid().ToString("N")));
            tmpDirectory.Create();

            StatusProgressBar.Style = ProgressBarStyle.Marquee;
            StatusLabel.Text = "Loading...";
            FilesListControlsPanel.Enabled = false;
            CreateButton.Enabled = false;
            SensitivityTrackBar.Enabled = false;

            var sensitivity = (SensitivityTrackBar.Value / 10f).ToString(CultureInfo.InvariantCulture);

            try
            {
                var globalCount = 0;
                foreach (var selectedFile in _selectedFiles)
                {
                    var file = new FileInfo(selectedFile);
                    if (!file.Exists)
                    {
                        MessageBox.Show(this, $"The file {file.FullName} was not found.", "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    StatusLabel.Text = $"Reading {file.Name}...";

                    var information = await utils.Execute(
                        $"-i \"{selectedFile}\" -filter:v \"select=\'gt(scene,{sensitivity})\',showinfo\" -f null null.dump");

                    var timestamps = DumpExtractor.GetTimestamps(information).ToList();
                    timestamps.Insert(0, TimeSpan.Zero);

                    for (var i = 0; i < timestamps.Count; i++)
                    {
                        var timestamp = timestamps[i];
                        timestamp = timestamp.Add(TimeSpan.FromSeconds(1));

                        StatusLabel.Text =
                            $"Extracting slides from {file.Name} ({i + 1} of {timestamps.Count})";

                        var arguments =
                            $"-y -ss {timestamp:c} -i \"{file.FullName}\" -vframes 1 \"{Path.Combine(tmpDirectory.FullName, $"slide{globalCount + i}.png")}\"";
                        await utils.Execute(arguments);
                    }

                    globalCount += timestamps.Count;
                }

                if (SelectSlidesCheckBox.Checked)
                {
                    Process.Start(new ProcessStartInfo {FileName = tmpDirectory.FullName, UseShellExecute = true});

                    MessageBox.Show(this,
                        "Your file explorer just opened with all extracted slides. You may now delete slides (e.g. duplicates) or rename them for reordering (the pdf will be constructed from the slides in this folder, sorted by name ascending). Please click on OK if you are done.",
                        "Select slides", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                var images = tmpDirectory.GetFiles("*.png", SearchOption.TopDirectoryOnly).OrderBy(x => x.Name);
                if (!images.Any())
                {
                    MessageBox.Show(this, "No slides were found.", "Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                Size imgSize;
                using (var img = Image.FromFile(images.First().FullName))
                {
                    imgSize = img.Size;
                }

                if (PdfSaveFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    var path = PdfSaveFileDialog.FileName;
                    using (var writer = new PdfWriter(path))
                    {
                        var pdfDocument = new PdfDocument(writer);

                        var doc = new Document(pdfDocument, new PageSize(imgSize.Width, imgSize.Height));

                        foreach (var imgFile in images)
                        {
                            var imgData = ImageDataFactory.CreatePng(new Uri("file://" + imgFile.FullName));
                            doc.Add(new iText.Layout.Element.Image(imgData));
                        }

                        doc.Close();
                    }

                    Process.Start("explorer.exe", $"/select, \"{path}\"");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"An error occurred:\r\n{exception}", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                StatusProgressBar.Style = ProgressBarStyle.Blocks;
                StatusLabel.Text = "Ready";
                CreateButton.Enabled = true;
                FilesListControlsPanel.Enabled = true;
                SensitivityTrackBar.Enabled = true;

                tmpDirectory.Delete(true);
            }
        }

        private void SensitivityTrackBar_Scroll(object sender, EventArgs e)
        {
            SensitivityLabel.Text = $"Sensitivity ({SensitivityTrackBar.Value / 10f})";
        }
    }
}