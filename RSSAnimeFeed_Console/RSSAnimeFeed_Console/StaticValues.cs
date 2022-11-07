using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace RSSAnimeFeed_Console
{
    // enum
    public enum EFileType
    {
        Json, Ini
    }

    public class StaticValues
    {
        // field
        public static readonly string RssFeedUrl;

        public static readonly char seperator;
        public static readonly string MainDirectory;
        public static readonly CreateFilePath Ping_Anime_Title_Json;
        public static readonly CreateFilePath Old_Anime_Title_Json;
        public static readonly CreateFilePath Configuration_Ini;

        // constructor
        static StaticValues()
        {
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
        public CreateFilePath(EFileType fileType , string fileName, string filePath, string fileFullPath)
        {
            FileName        = fileName;
            FilePath        = filePath;
            FileFullPath    = fileFullPath;
            FileType        = fileType;
        }
    }
}
