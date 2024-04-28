namespace mIRE.World.Domain
{
    public class Mech
    {
        public string Key { get; set; } = string.Empty;

        public HashSet<string> Keywords { get; set; }  = new HashSet<string>();

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<string> ThingKeys { get; set; } = new List<string>();        

        public List<Thing> Things { get; set; } = new List<Thing>();

        public void Hydrate(Dream dream) 
        { 
            foreach (var key in ThingKeys) 
            {
                Things.Add(dream.ThingDictionary[key]);
            }
        }
    }
}
