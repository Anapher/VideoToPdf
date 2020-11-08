namespace VideoToPdf
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.CreateButton = new System.Windows.Forms.Button();
            this.StatusProgressBar = new System.Windows.Forms.ProgressBar();
            this.FilesListBox = new System.Windows.Forms.ListBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.SelectSlidesCheckBox = new System.Windows.Forms.CheckBox();
            this.AddVideoOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.PdfSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.FilesListControlsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SensitivityTrackBar = new System.Windows.Forms.TrackBar();
            this.SensitivityLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FilesListControlsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateButton
            // 
            this.CreateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CreateButton.Location = new System.Drawing.Point(524, 332);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(112, 34);
            this.CreateButton.TabIndex = 0;
            this.CreateButton.Text = "Create PDF";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // StatusProgressBar
            // 
            this.StatusProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusProgressBar.Location = new System.Drawing.Point(12, 332);
            this.StatusProgressBar.Name = "StatusProgressBar";
            this.StatusProgressBar.Size = new System.Drawing.Size(506, 23);
            this.StatusProgressBar.TabIndex = 1;
            // 
            // FilesListBox
            // 
            this.FilesListBox.AllowDrop = true;
            this.FilesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilesListBox.FormattingEnabled = true;
            this.FilesListBox.ItemHeight = 15;
            this.FilesListBox.Location = new System.Drawing.Point(12, 12);
            this.FilesListBox.Name = "FilesListBox";
            this.FilesListBox.Size = new System.Drawing.Size(624, 199);
            this.FilesListBox.TabIndex = 2;
            this.FilesListBox.SelectedValueChanged += new System.EventHandler(this.FilesListBox_SelectedValueChanged);
            this.FilesListBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.FilesListBox_DragDrop);
            this.FilesListBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.FilesListBox_DragEnter);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddButton.Location = new System.Drawing.Point(3, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(86, 23);
            this.AddButton.TabIndex = 3;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // RemoveButton
            // 
            this.RemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveButton.Enabled = false;
            this.RemoveButton.Location = new System.Drawing.Point(95, 3);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(86, 23);
            this.RemoveButton.TabIndex = 3;
            this.RemoveButton.Text = "Remove";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MoveUpButton.Enabled = false;
            this.MoveUpButton.Location = new System.Drawing.Point(187, 3);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(86, 23);
            this.MoveUpButton.TabIndex = 3;
            this.MoveUpButton.Text = "Move Up";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.MoveDownButton.Enabled = false;
            this.MoveDownButton.Location = new System.Drawing.Point(279, 3);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(86, 23);
            this.MoveDownButton.TabIndex = 3;
            this.MoveDownButton.Text = "Move down";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // SelectSlidesCheckBox
            // 
            this.SelectSlidesCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectSlidesCheckBox.AutoSize = true;
            this.SelectSlidesCheckBox.Location = new System.Drawing.Point(389, 229);
            this.SelectSlidesCheckBox.Name = "SelectSlidesCheckBox";
            this.SelectSlidesCheckBox.Size = new System.Drawing.Size(247, 19);
            this.SelectSlidesCheckBox.TabIndex = 4;
            this.SelectSlidesCheckBox.Text = "Manually select slides before creating PDF";
            this.SelectSlidesCheckBox.UseVisualStyleBackColor = true;
            // 
            // AddVideoOpenFileDialog
            // 
            this.AddVideoOpenFileDialog.Filter = "Video files|*.mp4;*.avi;*.mov;*.mpv|All files|*.*";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(12, 358);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(39, 15);
            this.StatusLabel.TabIndex = 5;
            this.StatusLabel.Text = "Ready";
            // 
            // PdfSaveFileDialog
            // 
            this.PdfSaveFileDialog.Filter = "PDF file|*.pdf";
            this.PdfSaveFileDialog.Title = "Please select the location the pdf should be saved to";
            // 
            // FilesListControlsPanel
            // 
            this.FilesListControlsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.FilesListControlsPanel.Controls.Add(this.AddButton);
            this.FilesListControlsPanel.Controls.Add(this.RemoveButton);
            this.FilesListControlsPanel.Controls.Add(this.MoveUpButton);
            this.FilesListControlsPanel.Controls.Add(this.MoveDownButton);
            this.FilesListControlsPanel.Location = new System.Drawing.Point(9, 223);
            this.FilesListControlsPanel.Name = "FilesListControlsPanel";
            this.FilesListControlsPanel.Size = new System.Drawing.Size(369, 27);
            this.FilesListControlsPanel.TabIndex = 6;
            // 
            // SensitivityTrackBar
            // 
            this.SensitivityTrackBar.Location = new System.Drawing.Point(9, 283);
            this.SensitivityTrackBar.Minimum = 1;
            this.SensitivityTrackBar.Name = "SensitivityTrackBar";
            this.SensitivityTrackBar.Size = new System.Drawing.Size(206, 45);
            this.SensitivityTrackBar.TabIndex = 7;
            this.SensitivityTrackBar.Value = 1;
            this.SensitivityTrackBar.Scroll += new System.EventHandler(this.SensitivityTrackBar_Scroll);
            // 
            // SensitivityLabel
            // 
            this.SensitivityLabel.AutoSize = true;
            this.SensitivityLabel.Location = new System.Drawing.Point(13, 265);
            this.SensitivityLabel.Name = "SensitivityLabel";
            this.SensitivityLabel.Size = new System.Drawing.Size(86, 15);
            this.SensitivityLabel.TabIndex = 8;
            this.SensitivityLabel.Text = "Sensitivity (0.1)";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(221, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(415, 63);
            this.label2.TabIndex = 9;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(648, 378);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SensitivityLabel);
            this.Controls.Add(this.SensitivityTrackBar);
            this.Controls.Add(this.FilesListControlsPanel);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.SelectSlidesCheckBox);
            this.Controls.Add(this.FilesListBox);
            this.Controls.Add(this.StatusProgressBar);
            this.Controls.Add(this.CreateButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Video to PDF";
            this.FilesListControlsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SensitivityTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.ProgressBar StatusProgressBar;
        private System.Windows.Forms.ListBox FilesListBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.CheckBox SelectSlidesCheckBox;
        private System.Windows.Forms.OpenFileDialog AddVideoOpenFileDialog;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.SaveFileDialog PdfSaveFileDialog;
        private System.Windows.Forms.FlowLayoutPanel FilesListControlsPanel;
        private System.Windows.Forms.TrackBar SensitivityTrackBar;
        private System.Windows.Forms.Label SensitivityLabel;
        private System.Windows.Forms.Label label2;
    }
}

