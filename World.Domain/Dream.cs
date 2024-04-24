namespace mIRE.World.Domain
{
    public class Dream
    {
        //  max length 4
        public string Key { get; set; } = string.Empty;

        public string ShortName { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public Dictionary<string, Cell> Cells { get; set; } = new Dictionary<string, Cell>();
    }
}
