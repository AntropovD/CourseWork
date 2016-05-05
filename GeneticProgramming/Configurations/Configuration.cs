using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GeneticProgramming.Genetic;
using GeneticProgramming.Simulator.Maps;

namespace GeneticProgramming
{
    [Serializable]
    public class Configuration
    {
        public GeneticConfig GeneticConfig { get; set; }

        public MapConfig MapConfig { get; set; }

        public TankConfig TankConfig { get; set; }
    

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
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                result = (Configuration)formatter.Deserialize(fs);
            }
            return result;
        }
    }
}
