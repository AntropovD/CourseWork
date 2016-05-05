using System;
using System.IO;
using System.Xml.Serialization;

namespace GeneticProgramming.Simulator.Maps
{
    [Serializable]
    public class MapConfig
    {
        public int width;
        public int height;

        public int obstacles;
        public int enemies;

        public void SerializeToFile(string filename)
        {
            var formatter = new XmlSerializer(typeof(MapConfig));
            using (var fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, this);
            }
        }

        public static MapConfig DeserializeFromFile(string filename)
        {
            MapConfig result;
            var formatter = new XmlSerializer(typeof(MapConfig));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                result = (MapConfig)formatter.Deserialize(fs);
            }
            return result;
        }
    }
}
