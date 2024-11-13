using System;
using System.IO;
using Newtonsoft.Json;

namespace Assets.Scripts.Save
{
    internal class DataSerializer
    {
        public static string BaseDir
        {
            get => 
                $"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}" +
                $"{Path.DirectorySeparatorChar}.cryptoDungeon";
        }

        public static bool TryLoad<T>(string filename, out T result)
        {
            EnsureCreateDirectory(BaseDir);

            result = default;

            string fullpath = ConstructFullPath(filename);
            if (!File.Exists(fullpath))
                return false;

            string JSON = File.ReadAllText(fullpath);
            result = JsonConvert.DeserializeObject<T>(JSON);

            return true;
        }

        public static void Save<T>(T obj, string filename)
        {
            EnsureCreateDirectory(BaseDir);

            string JSON = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(ConstructFullPath(filename), JSON);
        }

        private static void EnsureCreateDirectory(string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);
        }

        private static string ConstructFullPath(string filename) => $"{BaseDir}\\{filename}.json";
    }
}
