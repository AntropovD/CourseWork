using System;
using System.IO;
using System.Xml.Serialization;

namespace GeneticProgramming.Genetic
{
    [Serializable]
    public class GeneticConfiguration
    {
        public int InitialPopulationSize = 16;
        public int MaximumPopulationSize = 64;
        public int MaximumProgramSize = 128;

        public double CrossoverProb = 0.90;
        public double MutationProb = 0.05;

        public double PanmixiaRatio = 0.40;
        public double InbreedRatio = 0.30;
        public double OutbreedRatio = 0.30;


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
