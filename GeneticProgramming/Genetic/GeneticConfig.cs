using System;
using System.IO;
using System.Xml.Serialization;

namespace GeneticProgramming.Genetic
{
    [Serializable]
    public class GeneticConfig
    {
        public int PopulationSize;
        public int MaxStrategySize;
        
        public double CrossoverProb;
        public double MutationProb;

        public double PanmixiaRatio;
        public double InbreedRatio;
        public double OutbreedRatio;

        public void SerializeToFile(string filename)
        {
            var formatter = new XmlSerializer(typeof(GeneticConfig));
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }

        public static GeneticConfig DeserializeFromFile(string filename)
        {
            GeneticConfig result;
            var formatter = new XmlSerializer(typeof(GeneticConfig));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                result = (GeneticConfig) formatter.Deserialize(fs);
            }
            return result;
        }
    }
}
