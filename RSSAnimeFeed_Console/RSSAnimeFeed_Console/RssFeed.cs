using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SimpleFeedReader;

namespace RSSAnimeFeed_Console
{
    public class RssFeed
    {
        // field
        public readonly char seperator = StaticValues.seperator;
        //public string Empty_Propertie { get; set; }

        // constructor
        /*
        public RssFeed()
        {
        }
        */

        /// <summary>
        /// https://github.com/RobThree/SimpleFeedReader
        /// Read RSS Recently Added Anime Videos from Crunchycroll
        /// </summary>
        public List<FeedItem> CheckNewAnimeTitleExist()
        {
            IOJsonGeneric<List<FeedItem>> tempJasonFile;

            List<FeedItem> newSaveAnimeTitle = new List<FeedItem>();        // save new animes
            List<FeedItem> oldLoadAnimeTitle = new List<FeedItem>();        // load old animes
            List<FeedItem> pingUpcomingAnimeTitle = new List<FeedItem>();   // ping new animes via weebhook ect.

            // if file exist -> load anime title file in memory 

            tempJasonFile = new IOJsonGeneric<List<FeedItem>>(StaticValues.Old_Anime_Title_Json);
            newSaveAnimeTitle = ReadRssFeedAnimeTitle();        // read new anime title from rss feed

            if (File.Exists(StaticValues.Old_Anime_Title_Json.FileFullPath) == false)
            {
                tempJasonFile.SaveJson(newSaveAnimeTitle);     // if not exist create old anime title file
            }

            oldLoadAnimeTitle = tempJasonFile.LoadJson();      // load old anime title file

            pingUpcomingAnimeTitle = CompareOldNewAnimeTitle(oldLoadAnimeTitle, newSaveAnimeTitle);    // create updated anime ping list 
            tempJasonFile.SaveJson(newSaveAnimeTitle);                                                // update old anime file

            tempJasonFile = new IOJsonGeneric<List<FeedItem>>(StaticValues.Ping_Anime_Title_Json);
            tempJasonFile.SaveJson(pingUpcomingAnimeTitle);                                           // save anime ping list

            // view console anime files
            ViewInConsole.ViewList(pingUpcomingAnimeTitle, "Updated Anime title to ping: ");
            ViewInConsole.ViewList(newSaveAnimeTitle, "All Rss Feed animes");

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
                string rssFeedUrl = StaticValues.RssFeedUrl;
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
        /// 
        public List<FeedItem> CompareOldNewAnimeTitle(List<FeedItem> oldAnimeList, List<FeedItem> newAnimelist)
        {
            // 
            int latestOldAnimeDay = GetDayOfTime(oldAnimeList.ElementAt(0));
            int newAnimeDay       = GetDayOfTime(newAnimelist.ElementAt(0));
            int tempAnimeDay      = 0;

            //oldAnimeList.RemoveRange(0, 0);       // only for testing
            List<FeedItem> returnNewAnims = new List<FeedItem>();
            //int oldAnimeListCount = oldAnimeList.Count;
            //int newAnimelistCount = newAnimelist.Count;

            if (oldAnimeList != null && newAnimelist != null)
            {
                for (int i = 0; i < newAnimelist.Count; i++)
                {
                    tempAnimeDay = GetDayOfTime(newAnimelist.ElementAt(i));
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
        public int GetDayOfTime(FeedItem value)
        {
            if (value == null)
            {
                return 0;
            }
            return value.Date.Year + value.Date.DayOfYear;
        }
    }
}
