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

        char seperator = Path.DirectorySeparatorChar;

        public void CheckNewAnimes()
        {
            /*
            string newAnimeFile = $"New_Anime_Title.json";
            string newAnimeFilePath = $"Rss_Feed_Files";
            string newAnimeFileFullPath = newAnimeFilePath + seperator + newAnimeFile;
            */

            string oldAnimeFile = $"Old_Anime_Title.json";
            string oldAnimeFilePath = $"Rss_Feed_Files";
            string oldAnimeFileFullPath = oldAnimeFilePath + seperator + oldAnimeFile;

            SaveLoadJsonGeneric<List<FeedItem>> slJasonGeneric;
            List<FeedItem> newSaveAnimeTitle = new List<FeedItem>();        // save new animes
            List<FeedItem> oldLoadAnimeTitle = new List<FeedItem>();        // load old animes
            List<FeedItem> pingUpcomingAnimeTitle = new List<FeedItem>();   // ping new animes via discord

            // if file exist -> load anime title file in memory 
            if (File.Exists(oldAnimeFileFullPath) == true)
            {
                slJasonGeneric = new SaveLoadJsonGeneric<List<FeedItem>>(oldAnimeFile, oldAnimeFilePath, oldAnimeFileFullPath);
                newSaveAnimeTitle = ReadNewAnimeTitleRssFeed(); // read new anime title from rss feed
                oldLoadAnimeTitle = slJasonGeneric.LoadJson();  // load old anime title file

                // ping only the newest anime title
                pingUpcomingAnimeTitle = returnNewAnims(oldLoadAnimeTitle, newSaveAnimeTitle);  
                // save new anime list 
            }

            // file not exist -> read rss feed and save anime title in file
            if (File.Exists(oldAnimeFileFullPath) == false)
            {
                slJasonGeneric = new SaveLoadJsonGeneric<List<FeedItem>>(oldAnimeFile, oldAnimeFilePath, oldAnimeFileFullPath);
                newSaveAnimeTitle = ReadNewAnimeTitleRssFeed(); // read new anime title from rss feed
                slJasonGeneric.SaveJson(newSaveAnimeTitle);     // save new anime title to file
                                                                // ping only the newest anime title
            }


        }


        /// </summary>+
        public List<FeedItem> ReadNewAnimeTitleRssFeed()
        {
            try
            {
                string rssFeedUrl = "http://feeds.feedburner.com/crunchyroll/rss/anime?lang=deDE";
                Console.WriteLine("Load rss feed from url: " + rssFeedUrl);

                FeedReader rddFeedReader = new FeedReader();
                IEnumerable<FeedItem> rssFeedItems = rddFeedReader.RetrieveFeed(rssFeedUrl);

                List<FeedItem> feedList = new List<FeedItem>();
                foreach (FeedItem feedItem in rssFeedItems)
                {
                    feedList.Add(feedItem);
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

                return feedList;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
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
