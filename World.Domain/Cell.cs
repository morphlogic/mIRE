namespace mIRE.World.Domain
{
    public class Cell
    {
        //  max length 8
        public string Key { get; set; } = string.Empty;

        public string ShortName { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<string> ThingKeys { get; set; } = new List<string>();

        public List<string> MechKeys { get; set; } = new List<string>();

        public List<Thing> Things { get; set; } = new List<Thing>();

        public List<Mech> Mechs { get; set; } = new List<Mech>();

        public List<Player> PlayerCharacters { get; set; } = new List<Player>();

        public List<Exit> Exits { get; set; } = new List<Exit>();

        //public Dictionary<string, Exit> Exits { get; set; } = new Dictionary<string, Exit>();

        public void Hydrate(Dream dream)
        {
            foreach(var key in ThingKeys)
            {
                Things.Add(dream.ThingDictionary[key]);
            }

            foreach(var key in MechKeys)
            {
                Mechs.Add(dream.MechDictionary[key]);
            }
        }

        public void Hydrate(dynamic dCell)
        {
            Key = dCell.key;
            ShortName = dCell.shortName;
            FullName = dCell.fullName;
            Description = dCell.description;
        }
    }
}