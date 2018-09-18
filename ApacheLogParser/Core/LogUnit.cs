using System;
using System.Globalization;

namespace ApacheLogParser
{
    internal class LogUnit
    {
        string datePatern = "dd/MMM/yyyy':'HH':'mm':'ss zzzzz";

        public IpUnit Ip { get; set; }
        public DateTime Time { get => DateTime.ParseExact(DateString, datePatern, CultureInfo.InvariantCulture); }
        public string DateString { get; set; }
        public string Type { get; set; }
        public int Response { get; set; }
        public ulong ResponseSize { get; set; }
        public FileUnit File { get; set; }
    }
}
