using System;
using System.IO;
using System.Xml.Serialization;
using GeneticProgramming.Configurations.PartialConfigs;

namespace GeneticProgramming.Configurations
{
    [Serializable]
    public class Configuration
    {
        public GeneticConfig GeneticConfig { get; set; }
        public MapConfig MapConfig { get; set; }
        public StrategyGeneratorConfig StrategyGeneratorConfig { get; set; }
        
        public void SerializeToFile(string filename)
        {
            var formatter = new XmlSerializer(typeof(Configuration));
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }
        public static Configuration DeserializeFromFile(string filename)
        {
            Configuration result;
            var formatter = new XmlSerializer(typeof(Configuration));
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                result = (Configuration)formatter.Deserialize(fs);
            }
            return result;
        }
    }
}
