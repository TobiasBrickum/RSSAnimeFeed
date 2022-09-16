// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleFeedReader;
using RSSAnimeFeed_Console.Discord_Bot;

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
            List<FeedItem> pingAnimes = CheckNewAnimeTitle();   // get rss anime feed list
            new Program().MainAsync(pingAnimes);                // Async is important for discord bot
        }

        public async Task MainAsync(List<FeedItem> pingAnimes)  // Async Discord
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\tShiki Say: Hello, World! In MainAsync Method :)");

            SendAnimesToDiscordBot(pingAnimes);                 // ping updatet animes
        }

        public async void SendAnimesToDiscordBot(List<FeedItem> pingAnimes)
        {
            DiscordPingBot animePingBot = new DiscordPingBot(pingAnimes);
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<FeedItem> CheckNewAnimeTitle()
        {
            RSSLibarie rssrReader = new RSSLibarie();
            return rssrReader.CheckNewAnimeTitleExist();
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

