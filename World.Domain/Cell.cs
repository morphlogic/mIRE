namespace mIRE.World.Domain
{
    public class Cell
    {
        //  max length 8
        public string Key { get; set; } = string.Empty;

        public string ShortName { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<MechanicalCharacter> MechanicalCharacters { get; set; } = new List<MechanicalCharacter>();

        public List<PlayerCharacter> PlayerCharacters { get; set; } = new List<PlayerCharacter>();

        public Dictionary<string, Exit> Exits { get; set; } = new Dictionary<string, Exit>();
    }
}