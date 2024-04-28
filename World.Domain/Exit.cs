namespace mIRE.World.Domain
{
    public class Exit
    {
        //  max length 16
        public string Key { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Distance { get; set; } = 0;

        public string CellKey { get; set; } = string.Empty;

        public Cell Cell { get; set; } = new Cell();
    }
}