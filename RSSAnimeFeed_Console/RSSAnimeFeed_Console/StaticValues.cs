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
    public class StaticValues
    {
        // field
        public static readonly string RssFeedUrl;

        public static readonly char seperator;
        public static readonly string MainDirectory;
        public static readonly CreateFilePath Ping_Anime_Title_Json;
        public static readonly CreateFilePath Old_Anime_Title_Json;

        // constructor
        static StaticValues()
        {
            RssFeedUrl = "https://www.crunchyroll.com/rss/anime?lang=deDE"; // from https://www.crunchyroll.com/de/feed

            seperator = Path.DirectorySeparatorChar;
            MainDirectory = "Rss_Feed_Files";
            
            string newPingFile = $"Ping_Anime_Title.json";
            string newPingFilePath = MainDirectory;
            string newPingFileFullPath = newPingFilePath + seperator + newPingFile;
            Ping_Anime_Title_Json = new CreateFilePath(newPingFile, newPingFilePath, newPingFileFullPath);

            string oldAnimeFile = $"Old_Anime_Title.json";
            string oldAnimeFilePath = MainDirectory;
            string oldAnimeFileFullPath = oldAnimeFilePath + seperator + oldAnimeFile;
            Old_Anime_Title_Json = new CreateFilePath(oldAnimeFile, oldAnimeFilePath, oldAnimeFileFullPath);
        }
    }

    public class CreateFilePath
    {
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public string FileFullPath { get; private set; }

        // constructor
        /// <summary>
        ///  
        /// </summary>
        /// <param name="fileName"> file.json </param>
        /// <param name="filePath"> folder </param>
        /// <param name="fileFullpath"> foler//file.json </param>
        public CreateFilePath(string fileName, string filePath, string fileFullPath)
        {
            FileName = fileName;
            FilePath = filePath;
            FileFullPath = fileFullPath;
        }
    }


}
