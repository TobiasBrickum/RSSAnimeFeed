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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\tShiki Say: Hello, World!");

            //DeleteCachFiles();
            //List<FeedItem> pingAnimes = CheckNewAnimeTitle();   // get rss anime feed list
            //List<FeedItem> pingAnimes = new List<FeedItem>();   // get rss anime feed list
        }

        /// <summary>
        /// 
        /// </summary>
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
            string directoryName = "Rss_Feed_Files";
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

