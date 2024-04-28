using mIRE.World.Domain;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace mIRE.World.Editor.Console
{
    internal class FileWorldParser
    {
        internal Dream LoadSandbox()
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(HyphenatedNamingConvention.Instance)
                .Build();

            var x0 = File.ReadAllText("SandboxWorld\\X0.yaml");

            var dreamX0 = deserializer.Deserialize<Dream>(x0);

            dreamX0.Hydrate();
            
            //  TODO:   return World w/ dreams instead
            return dreamX0;
        }
    }    
}
