using System;
using System.IO;
using System.Xml.Serialization;

namespace GeneticProgramming.Genetic
{
    [Serializable]
    public class GeneticConfiguration
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
            var formatter = new XmlSerializer(typeof(GeneticConfiguration));
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }

        public static GeneticConfiguration DeserializeFromFile(string filename)
        {
            GeneticConfiguration result;
            var formatter = new XmlSerializer(typeof(GeneticConfiguration));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                result = (GeneticConfiguration) formatter.Deserialize(fs);
            }
            return result;
        }
    }
}
