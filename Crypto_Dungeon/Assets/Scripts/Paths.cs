using Assets.Scripts.Save;
using System;
using System.IO;
using UnityEngine;

namespace Assets
{
    public class Paths
    {
        public const string SAVES_FILENAME = "saves";

        public static string BaseSavesDir
        {
            get =>
                @$"{Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)}" +
                @$"{Path.DirectorySeparatorChar}.cryptoDungeon";
        }

        public static Localization Localization { get => GameSaves.Instance.Localization; }
        private static readonly char sep = Path.DirectorySeparatorChar;


        public static string GetHintImagePath(string cipherName) => 
            @$"{Application.streamingAssetsPath}{sep}{Localization}{sep}HintImages{sep}{cipherName}.png";

        public static string GetTitlesPath() => 
            @$"{Application.streamingAssetsPath}{sep}{Localization}{sep}Titles{sep}Titles.txt";

        public static string GetSubtitlesPath(string filename, SubtitilesType type, int index) => 
            @$"{Application.streamingAssetsPath}{sep}{Localization}{sep}Subtitles{sep}{type}{sep}{filename}{sep}{index}.txt";

        public static string GetSubtitlesPath(string filename, SubtitilesType type) =>
            @$"{Application.streamingAssetsPath}{sep}{Localization}{sep}Subtitles{sep}{type}{sep}{filename}.txt";

        public static string GetSpritesDirPath(string presentationName) =>
            @$"{Application.streamingAssetsPath}{sep}{Localization}{sep}Presentations{sep}{presentationName}";

        public static string GetSaveFileFullPathByName(string filename) => @$"{BaseSavesDir}{sep}{filename}.json";
    }
}
