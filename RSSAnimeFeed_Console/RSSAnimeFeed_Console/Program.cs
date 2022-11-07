// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Discord.Net;
using Discord.WebSocket;
using Newtonsoft.Json;
using SimpleFeedReader;


namespace RSSAnimeFeed_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            StaticValues loadApplicationSettings = new StaticValues();
            Console.WriteLine("\n\tShiki Say: Hello, World!");

            //CreateIniTestFile();

            //DeleteCachFiles();
            //List<FeedItem> pingAnimes = CheckNewAnimeTitle();   // get rss anime feed list
            //List<FeedItem> pingAnimes = new List<FeedItem>();   // get rss anime feed list
        }

        public static void CreateIniTestFile()
        {
            SaveLoadFile<string> saveLoadFile = new SaveLoadFile<string>(StaticValues.Configuration_Ini);
            string value = "123";
            saveLoadFile.SaveFile(value);
            value = saveLoadFile.LoadFile();
        }

        public static void PushNewAnimeTitle()
        {
            RssFeed rssrReader = new RssFeed(); // get rss feed anime title
            RssFeedWeebHook rssFeedWeebHook = new RssFeedWeebHook(rssrReader.CheckNewAnimeTitleExist()); // push weebhook anime title 
        }

        /// <summary>
        /// Detele programm folder
        /// </summary>
        public static void DeleteCachFiles()
        {
            string directoryName = StaticValues.MainDirectory;
            try
            {
                if(Directory.Exists(directoryName) == true)
                {
                    Directory.Delete(directoryName, true);
                }
                Directory.CreateDirectory(directoryName);
            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

    }
}

