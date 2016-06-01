using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using log4net;

namespace GeneticProgramming.Simulator.Maps
{
    public static class MapSerializator
    {
        private static string folder = @"Logs\Generations\";
        private static string file = "Map.dat";
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static void Serialize(Map map)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(folder + file, FileMode.OpenOrCreate))
            {
                try
                {
                    formatter.Serialize(fs, map);
                }
                catch (SerializationException)
                {
                    log.Error("Map Serialization problems:(");
                }
                catch (SecurityException)
                {
                    log.Error("Map serialization. Cannot access to map.dat file.");
                }
            }
        }

        public static Map Deserialise(string path)
        {
            Map result;
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                result = (Map) formatter.Deserialize(fs);
            }
            return result;
        }
    }
}
