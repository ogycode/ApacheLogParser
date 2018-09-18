namespace ApacheLogParser
{
    internal class FileUnit
    {
        public string Path { get; set; }
        public int Size { get; set; }
        public string HTMLTitle { get; set; }

        public int Id = -1;

        public FileUnit()
        {
            Path = "-";
            Size = 0;
            HTMLTitle = "-";
        }
        public FileUnit(string Path) : this()
        {
            this.Path = Path;
        }

        public override string ToString() => $"{Path} | {HTMLTitle} | {Size}";
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is FileUnit))
                return false;

            return Path.Equals((obj as FileUnit).Path);
        }
        public override int GetHashCode() => $"{Path}{HTMLTitle}{Size}".GetHashCode();
    }
}
