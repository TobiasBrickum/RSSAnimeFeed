using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace RSSAnimeFeed_Console
{
    // enum
    public enum EFileType
    {
        Json, Ini, Env, UnitTest
    }

    public class StaticValues
    {
        // field
        public static readonly ConsoleColor ConsoleColorForeground;
        public static readonly ConsoleColor ConsoleColorBackground;

        public static readonly string RssFeedUrl;

        public static readonly char seperator;
        public static readonly string MainDirectory;
        public static readonly CreateFilePath Ping_Anime_Title_Json;
        public static readonly CreateFilePath Old_Anime_Title_Json;
        public static readonly CreateFilePath Configuration_Ini;

        // constructor
        static StaticValues()
        {
            ConsoleColorForeground = ConsoleColor.Green;
            ConsoleColorBackground = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColorForeground;
            Console.BackgroundColor = ConsoleColorBackground;

            RssFeedUrl = "https://www.crunchyroll.com/rss/anime?lang=deDE"; // from https://www.crunchyroll.com/de/feed

            seperator = Path.DirectorySeparatorChar;
            MainDirectory = "Rss_Feed_Files";
            
            string newPingFile = $"Ping_Anime_Title.json";
            string newPingFilePath = MainDirectory;
            string newPingFileFullPath = newPingFilePath + seperator + newPingFile;
            Ping_Anime_Title_Json = new CreateFilePath(EFileType.Json, newPingFile, newPingFilePath, newPingFileFullPath);

            string oldAnimeFile = $"Old_Anime_Title.json";
            string oldAnimeFilePath = MainDirectory;
            string oldAnimeFileFullPath = oldAnimeFilePath + seperator + oldAnimeFile;
            Old_Anime_Title_Json = new CreateFilePath(EFileType.Json, oldAnimeFile, oldAnimeFilePath, oldAnimeFileFullPath);            
            
            string testIniFile = $"Configuration.ini";
            string testIniFilePath = MainDirectory;
            string testIniFileFullPath = testIniFilePath + seperator + testIniFile;
            Configuration_Ini = new CreateFilePath(EFileType.Ini, testIniFile, testIniFilePath, testIniFileFullPath);

            if (!File.Exists(testIniFileFullPath))
            {
                //CreateDefaultSettings();
            }

            if (File.Exists(testIniFileFullPath))
            {
                //LoadDefaultSettings();
            }
        }

        private static void CreateDefaultSettings()
        {
            // using important because
            // file not exist   = file not found exception
            // file exist       = file not access because it is being used by another process. 
            using (File.Create(Configuration_Ini.FileFullPath));
            
            FileIniDataParser parser = new FileIniDataParser();
            IniData data = parser.ReadFile(Configuration_Ini.FileFullPath); 

            data["Application Settings"]["ConsoleColorForeground"] = "Green";
            data["Application Settings"]["ConsoleColorBackground"] = "Black";

            data["Rss Feed Settings"]["Url"] = "https://www.crunchyroll.com/rss/anime?lang=deDE";

            data["Weebhook Settings"]["Url"] = "";

            parser.WriteFile(Configuration_Ini.FileFullPath, data);
            /*
            SaveLoadFile<IniData> saveLoad = new SaveLoadFile<IniData>(Configuration_Ini);
            saveLoad.SaveFile(data);
            */
        }

        private static void LoadDefaultSettings()
        {
            FileIniDataParser parser = new FileIniDataParser();
            IniData data = parser.ReadFile(Configuration_Ini.FileFullPath);

            string useFullScreenStr = data["UI"]["fullscreen"];

            
            parser.WriteFile(Configuration_Ini.FileFullPath, data);
            // useFullScreenStr contains "true"
            bool useFullScreen = bool.Parse(useFullScreenStr);

        }

        public class CreatApplicationSettings
        {
            public CreatApplicationSettings()
            {
                LoadDefaultSettings();
            }
        }
    }

    public class CreateFilePath
    {
        // field
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public string FileFullPath { get; private set; }
        public EFileType FileType { get; private set; }

        // constructor
        public CreateFilePath() { }
        public CreateFilePath(EFileType fileType , string fileName, string filePath, string fileFullPath)
        {
            FileName        = fileName;
            FilePath        = filePath;
            FileFullPath    = fileFullPath;
            FileType        = fileType;
        }
    }


}
