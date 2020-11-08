using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace VideoToPdf
{
    public class FfmpegUtils
    {
        private readonly string _filename;

        public FfmpegUtils(string filename)
        {
            _filename = filename;
        }

        public async Task<string> Execute(string arguments)
        {
            var startInfo = new ProcessStartInfo
            {
                Arguments = arguments,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                FileName = _filename
            };

            var process = Process.Start(startInfo);
            if (process == null) throw new InvalidOperationException("The ffmpeg process could not be started");

            var info = await process.StandardError.ReadToEndAsync();
            if (process.ExitCode != 0)
            {
                Console.WriteLine(info);
                throw new InvalidOperationException(
                    $"FFMpeg process exited with code {process.ExitCode}\r\n\r\n{info}");
            }

            return info;
        }
    }
}