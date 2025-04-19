using System.IO;
using Newtonsoft.Json;

namespace Assets.Scripts.Save
{
    internal class SavesSerializer
    {
        public static bool TryLoad<T>(string filename, out T result)
        {
            EnsureCreateDirectory(Paths.BaseSavesDir);

            result = default;

            string fullPath = Paths.GetSaveFileFullPathByName(filename);
            if (!File.Exists(fullPath))
                return false;

            string JSON = File.ReadAllText(fullPath);
            result = JsonConvert.DeserializeObject<T>(JSON);

            return true;
        }

        public static void Save<T>(T obj, string filename)
        {
            EnsureCreateDirectory(Paths.BaseSavesDir);

            string JSON = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(Paths.GetSaveFileFullPathByName(filename), JSON);
        }

        private static void EnsureCreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }
    }
}
