namespace mIRE.World.Domain
{
    public class Player
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public List<Thing> Things { get; set; } = new List<Thing>();
    }
}
