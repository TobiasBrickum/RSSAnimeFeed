using RSSAnimeFeed_Console.Discord_Bot;
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
    public enum enumWeekDay : int { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    public class RSSLibarie
    {
        // field
        char seperator = Path.DirectorySeparatorChar;
        //public string Empty_Propertie { get; set; }

        // constructor
        public RSSLibarie()
        {
        }

        /// <summary>
        /// https://github.com/RobThree/SimpleFeedReader
        /// Read RSS Recently Added Anime Videos from Crunchycroll
        /// </summary>
        public List<FeedItem> CheckNewAnimeTitleExist()
        {
            string npingUpcomingAnimeTitleFile = $"Ping_Anime_Title.json";
            string pingUpcomingAnimeTitleFilePath = $"Rss_Feed_Files";
            string pingUpcomingAnimeTitleFileFullPath = pingUpcomingAnimeTitleFilePath + seperator + npingUpcomingAnimeTitleFile;

            string oldAnimeFile = $"Old_Anime_Title.json";
            string oldAnimeFilePath = $"Rss_Feed_Files";
            string oldAnimeFileFullPath = oldAnimeFilePath + seperator + oldAnimeFile;

            SaveLoadJsonGeneric<List<FeedItem>> slJasonGeneric;
            List<FeedItem> newSaveAnimeTitle = new List<FeedItem>();        // save new animes
            List<FeedItem> oldLoadAnimeTitle = new List<FeedItem>();        // load old animes
            List<FeedItem> pingUpcomingAnimeTitle = new List<FeedItem>();   // ping new animes via discord

            // if file exist -> load anime title file in memory 

            slJasonGeneric = new SaveLoadJsonGeneric<List<FeedItem>>(oldAnimeFile, oldAnimeFilePath, oldAnimeFileFullPath);
            newSaveAnimeTitle = ReadRssFeedAnimeTitle();        // read new anime title from rss feed

            if (File.Exists(oldAnimeFileFullPath) == false)
            {
                slJasonGeneric.SaveJson(newSaveAnimeTitle);     // if not exist create old anime title file
            }

            oldLoadAnimeTitle = slJasonGeneric.LoadJson();      // load old anime title file

            pingUpcomingAnimeTitle = CompareOldNewAnimeTitle(oldLoadAnimeTitle, newSaveAnimeTitle);    // create updated anime ping list 
            slJasonGeneric.SaveJson(newSaveAnimeTitle);                                                // update old anime file

            slJasonGeneric = new SaveLoadJsonGeneric<List<FeedItem>>(npingUpcomingAnimeTitleFile, pingUpcomingAnimeTitleFilePath, pingUpcomingAnimeTitleFileFullPath);
            slJasonGeneric.SaveJson(pingUpcomingAnimeTitle);                                           // save anime ping list

            ViewInConsole.ViewList(pingUpcomingAnimeTitle, "Updated Anime title to ping: ");
            ViewInConsole.ViewList(newSaveAnimeTitle, "All Rss Feed animes");

            //feed discords bot with anime ping message
            return pingUpcomingAnimeTitle;
        }

        /// <summary>
        /// Return FeedItem list from rss feed url
        /// 
        /// </summary>
        /// <returns>Anime List</returns>
        public List<FeedItem> ReadRssFeedAnimeTitle()   // todo filter anime subs / dubs and language
        {
            try
            {
                //string rssFeedUrl = "http://feeds.feedburner.com/crunchyroll/rss/anime?lang=deDE"; // from https://www.crunchyroll.com/de/feed
                string rssFeedUrl = "https://www.crunchyroll.com/rss/anime?lang=deDE"; // from https://www.crunchyroll.com/de/feed
                Console.WriteLine("\nLoad Rss Feed from following url: " + rssFeedUrl);

                FeedReader rddFeedReader = new FeedReader();
                IEnumerable<FeedItem> rssFeedItems = rddFeedReader.RetrieveFeed(rssFeedUrl);

                List<FeedItem> animeList = new List<FeedItem>(); // create list from rss anime feed 
                foreach (FeedItem feedItem in rssFeedItems)
                {
                    animeList.Add(feedItem);
                }

                return animeList;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return null;
            }             
        }

        /// <summary>
        ///  todo <-- reconfig date with timestamps
        /// https://www.unixtimestamp.com/ reconfig date with timestamps
        /// </summary>
        /// <param name="oldAnimeList"></param>
        /// <param name="newAnimelist"></param>
        /// <returns></returns>
        [Obsolete] 
        public List<FeedItem> CompareOldNewAnimeTitle(List<FeedItem> oldAnimeList, List<FeedItem> newAnimelist)
        {
            // 
            int latestOldAnimeDay = GetDateDayOfTime(oldAnimeList.ElementAt(0));
            int newAnimeDay       = GetDateDayOfTime(newAnimelist.ElementAt(0));
            int tempAnimeDay      = 0;

            //oldAnimeList.RemoveRange(0, 0);       // only for testing
            List<FeedItem> returnNewAnims = new List<FeedItem>();
            int oldAnimeListCount = oldAnimeList.Count;
            int newAnimelistCount = newAnimelist.Count;

            if (oldAnimeList != null && newAnimelist != null)
            {
                for (int i = 0; i < newAnimelist.Count; i++)
                {
                    tempAnimeDay = GetDateDayOfTime(newAnimelist.ElementAt(i));
                    // add anime to returnList if anime realeased
                    if (tempAnimeDay >= latestOldAnimeDay) 
                    {
                        returnNewAnims.Add(newAnimelist.ElementAt(i));
                    }
                }           
            }
            return returnNewAnims;
        }

        /// <summary>
        /// return int '20221' from date 01.01.2022 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetDateDayOfTime(FeedItem value)
        {
            if (value == null)
            {
                return 0;
            }
            int ret = value.Date.Year + value.Date.DayOfYear;
            return ret;
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public void DiscordBotMessage(List<FeedItem> value)
        {

            DiscordPingBot discordPingBot = new DiscordPingBot();
        }
        */
    }
}
