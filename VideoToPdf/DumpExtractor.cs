using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace VideoToPdf
{
    public static class DumpExtractor
    {
        public static IEnumerable<TimeSpan> GetTimestamps(string ffmpegDump)
        {
            return Regex.Matches(ffmpegDump, @"(?<=pts_time:)\d+(\.\d{1,2})?")
                .Select(x => TimeSpan.FromSeconds(double.Parse(x.Value, CultureInfo.InvariantCulture)));
        }

        public static TimeSpan GetDuration(string ffmpegDump)
        {
            return TimeSpan.ParseExact(Regex.Match(ffmpegDump, @"(?<=Duration: )\d{2}:\d{2}:\d{2}\.\d{2}").Value,
                "hh\\:mm\\:ss\\.ff", CultureInfo.InvariantCulture);
        }
    }
}