namespace mIRE.World.Domain
{
    public class Dream
    {
        //  max length 4
        public string Key { get; set; } = string.Empty;

        public string ShortName { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string Dreamer { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<string> ThingKeys { get; set; } = new List<string>();

        public List<string> MechKeys { get; set; } = new List<string>();

        public List<Thing> Things { get; set; } = new List<Thing>();

        public Dictionary<string, Thing> ThingDictionary { get; set; } = new Dictionary<string, Thing>();

        public List<Mech> Mechs { get; set; } = new List<Mech>();

        public Dictionary<string, Mech> MechDictionary { get; set; } = new Dictionary<string, Mech>();

        public List<Cell> Cells { get; set; } = new List<Cell>();

        public Dictionary<string, Cell> CellDictionary { get; set; } = new Dictionary<string, Cell>();

        //public Dictionary<string, Cell> Cells { get; set; } = new Dictionary<string, Cell>();

        public void Hydrate()
        {            
            foreach(var thing in Things)
            {                
                ThingDictionary[thing.Key] = thing;
            }

            foreach(var mech in Mechs)
            {
                MechDictionary[mech.Key] = mech;
            }

            foreach (var cell in Cells)
            {
                CellDictionary[cell.Key] = cell;
            }

            foreach(var thing in Things)
            {
                thing.Hydrate(this);
            }

            foreach(var mech in Mechs)
            {
                mech.Hydrate(this);
            }

            foreach(var  cell in Cells)
            {
                cell.Hydrate(this);
            }
        }

        public void Hydrate(dynamic dream)
        {
            Key = dream.key;
            ShortName = dream.shortName;
            FullName = dream.fullName;
            Dreamer = dream.dreamer;
            Description = dream.description;

            foreach(dynamic dThing in dream["things"])
            {

            }

            foreach (dynamic dCell in dream["cells"])
            {
                var cell = new Cell();                                          
            }
        }
    }    
}
