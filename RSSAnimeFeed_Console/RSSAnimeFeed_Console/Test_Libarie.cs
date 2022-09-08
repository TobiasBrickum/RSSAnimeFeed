using RSSAnimeFeed_Console;
using SimpleFeedReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HTML_Downlaod_Konsole
{
    public enum enumWeekDay : int{ Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    public class RSSLibarie
    {
        /// <summary>
        /// https://github.com/RobThree/SimpleFeedReader
        /// Read RSS Recently Added Anime Videos from Crunchycroll


        /// </summary>+
        public IEnumerable<FeedItem> ReadNewAnimeTitleRss()
        {
            try
            {
                string rssUrl = "http://feeds.feedburner.com/crunchyroll/rss/anime?lang=deDE";
                Console.WriteLine("Read rss from link: " + rssUrl);

                FeedReader feedReader = new FeedReader();
                IEnumerable<FeedItem> rssFeedItems = feedReader.RetrieveFeed(rssUrl);

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
                return rssFeedItems;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }             
        }

        public void viewListInConsole(List<string> value)
        {
            string patcher = "#######################################################################################################################";
            Console.WriteLine("\n\t" + patcher);
            foreach (string line in value)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("\t" + patcher);
        }


        public void CheckNewAnimes()
        {
            string fileName = "Crunchycroll_RSS_Anime_Liste.json";
            string filePath = "";
            string fileFullPath = "Crunchycroll_RSS_Anime_Liste.json";        
            SaveLoadJson saveLoadJson = new SaveLoadJson(fileName, filePath, fileFullPath);
            FeedItem newsSaveRssAnimes = new FeedItem(); // save new animes
            FeedItem oldLoadRssAnimes = new FeedItem();  // load old animes
            FeedItem upcomingAnime = new FeedItem();     // ping new animes via discord

            // file not exist -> read rss anime list and save als file
            if (File.Exists(fileFullPath) == false)
            {
                newsSaveRssAnimes = ReadNewAnimeTitleRss();
                saveLoadJson.SaveJson(newsSaveRssAnimes);
                newsSaveRssAnimes = oldLoadRssAnimes;       // referenz
            }

            // is file exist -> read it and save as list 
            if (File.Exists(fileFullPath) == true)
            {
                newsSaveRssAnimes = ReadNewAnimeTitleRss();
                oldLoadRssAnimes = saveLoadJson.LoadJson();

                upcomingAnime = returnNewAnims(oldLoadRssAnimes, newsSaveRssAnimes);
            }
        

        }

        public List<string> returnNewAnims(List<string> oldAnimeList, List<string> newAnimelist)
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

                List<string> returnNewAnims = new List<string>();
                
            }

            return null;
        }


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
    }
}
