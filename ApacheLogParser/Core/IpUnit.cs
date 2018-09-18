namespace ApacheLogParser
{
    internal class IpUnit
    {
        public string Ip { get; set; }
        public string NetName { get; set; }

        public int Id = -1;

        public IpUnit()
        {
            Ip = "-";
            NetName = "-";
        }
        public IpUnit(string Ip) : this()
        {
            this.Ip = Ip;
        }

        public override string ToString() => $"{Ip} | {NetName}";
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is IpUnit))
                return false;

            return (obj as IpUnit).Ip.Equals(Ip);
        }
        public override int GetHashCode() => Ip.GetHashCode();
    }
}
