using RSSAnimeFeed_Console;
using SimpleFeedReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RSSAnimeFeed_Console
{
    public enum enumWeekDay : int{ Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    public class RSSLibarie
    {
        /// <summary>
        /// https://github.com/RobThree/SimpleFeedReader
        /// Read RSS Recently Added Anime Videos from Crunchycroll

        public void CheckNewAnimes()
        {
            string newAnimeFile = @"Crunchycroll_RSS_Anime_Liste.json";
            string newAnimeFilePath = @"RssFiles\";
            string newAnimeFileFullPath = @"RssFiles\Crunchycroll_RSS_Anime_Liste.json";
            newAnimeFileFullPath = SaveLoadJsonGeneric<string>.CeckPathStatic(newAnimeFile, newAnimeFilePath);

            /*
            string oldAnimeFile = @"Crunchycroll_RSS_Anime_Liste.json";
            string oldAnimeFilePath = @"RssFiles\";
            string oldAnimeFileFullPath = @"RssFiles\Crunchycroll_RSS_Anime_Liste.json";
            */
            SaveLoadJsonGeneric<List<FeedItem>> saveLoadJsonGeneric = new SaveLoadJsonGeneric<List<FeedItem>>(newAnimeFile, newAnimeFilePath, newAnimeFileFullPath);
            List<FeedItem> newsSaveRssAnimes = new List<FeedItem>(); // save new animes
            List<FeedItem> oldLoadRssAnimes = new List<FeedItem>();  // load old animes
            List<FeedItem> upcomingAnime = new List<FeedItem>();     // ping new animes via discord

            // file not exist -> read rss anime list and save als file
            if (File.Exists(newAnimeFileFullPath) == false)
            {
                newsSaveRssAnimes = ReadNewAnimeTitleRss();
                saveLoadJsonGeneric.SaveJsonGeneric(newsSaveRssAnimes);
                newsSaveRssAnimes = oldLoadRssAnimes;       // referenz
            }

            // is file exist -> read it and save as list 
            if (File.Exists(newAnimeFileFullPath) == true)
            {
                newsSaveRssAnimes = ReadNewAnimeTitleRss(); // todo clean double code 
                oldLoadRssAnimes = saveLoadJsonGeneric.LoadJsonGeneric();
                upcomingAnime = returnNewAnims(oldLoadRssAnimes, newsSaveRssAnimes);
            }
        }


        /// </summary>+
        public List<FeedItem> ReadNewAnimeTitleRss()
        {
            try
            {
                string rssUrl = "http://feeds.feedburner.com/crunchyroll/rss/anime?lang=deDE";
                Console.WriteLine("Read rss from link: " + rssUrl);

                FeedReader feedReader = new FeedReader();
                IEnumerable<FeedItem> rssFeedItems = feedReader.RetrieveFeed(rssUrl);

                List<FeedItem> test = new List<FeedItem>();
                foreach (FeedItem feedItem in rssFeedItems)
                {
                    test.Add(feedItem);
                    //Console.WriteLine($"{feedItem.Date.ToString("g")}\t{feedItem.Title}");
                    //Console.WriteLine(feedItem.Title);
                }

                /*
                // save readed anime titles
                List<string> rssAnimeTitle = new List<string>();
                foreach (FeedItem feedItem in rssFeedItems)
                {
                    rssAnimeTitle.Add(feedItem.Title);
                    //Console.WriteLine($"{feedItem.Date.ToString("g")}\t{feedItem.Title}");
                    //Console.WriteLine(feedItem.Title);
                }
                //viewListInConsole(rssAnimeTitle);
                */

                return test;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }             
        }


        public List<FeedItem> returnNewAnims(List<FeedItem> oldAnimeList, List<FeedItem> newAnimelist)
        {
            // reverse list because newest animes saved on index 0
            //oldAnimeList.Reverse();
            //newAnimelist.Reverse();

            if(oldAnimeList != null && newAnimelist != null)
            {
                if (oldAnimeList.Count == newAnimelist.Count)
                {
                    return null;
                }
                List<FeedItem> returnNewAnims = new List<FeedItem>();             
            }
            return null;
        }


        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="weekday"></param>
        /// <returns>return true if the weekday = the currebtlly day</returns>
        public bool viewCalendaryWeek(enumWeekDay weekDay)
        {
            DateOnly myDate = new DateOnly();
            string currentlyWeekDay = myDate.DayOfWeek.ToString();
            if (currentlyWeekDay == weekDay.ToString())
            {
                Console.WriteLine("\n\t" + "Time to refresh the anime realse title list :) " + weekDay);
                return true;
            }
            return false;
        }

        /// <summary>
        /// create Threaf for checking every draiday for a new anime title 
        /// </summary>
        public void CreateThreadForRssAnimeList()
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
        */

        public static void viewListInConsole(List<string> value)
        {
            string patcher = "#######################################################################################################################";
            Console.WriteLine("\n\t" + patcher);
            foreach (string line in value)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("\t" + patcher);
        }
    }
}
