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
        // field
        public string Empty_Propertie { get; set; }

        // constructor
        public RSSLibarie()
        {
            Empty_Propertie = "a";
        }

        // method

        /// <summary>
        /// https://github.com/RobThree/SimpleFeedReader
        /// Read RSS Recently Added Anime Videos from Crunchycroll

        char seperator = Path.DirectorySeparatorChar;

        public void CheckNewAnimeTitleExist()
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


            ViewListFeedIitle(pingUpcomingAnimeTitle, "Updated Anime title to ping: ");
            ViewListFeedIitle(newSaveAnimeTitle, "All Rss Feed animes");

            // feed discords bot with anime ping message
        }

        public void ViewListFeedIitle(List<FeedItem> animeList, string message)
        {
            Console.WriteLine("\n\n \t" + message);
            Console.WriteLine();
            foreach (FeedItem feedItem in animeList)
            {
                Console.WriteLine(feedItem.Date + "\t" + feedItem.Title);
            }
        }

        /// </summary>+
        public List<FeedItem> ReadRssFeedAnimeTitle()
        {
            try
            {
                string rssFeedUrl = "http://feeds.feedburner.com/crunchyroll/rss/anime?lang=deDE";
                Console.WriteLine("Load Rss Feed from following url: " + rssFeedUrl);

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


        // todo <-- reconfig date with timestamps
        [Obsolete] 
        public List<FeedItem> CompareOldNewAnimeTitle(List<FeedItem> oldAnimeList, List<FeedItem> newAnimelist)
        {
            // https://www.unixtimestamp.com/ reconfig date with timestamps
            DateTimeOffset latestOldAnimeDay = oldAnimeList.ElementAt(0).Date;
            DateTimeOffset newAnimeDay = newAnimelist.ElementAt(0).Date;
            FeedItem oldestAnimeDate = oldAnimeList.ElementAt(0);

            // only for testing
            //oldAnimeList.RemoveRange(0, 0);
            List<FeedItem> returnNewAnims = new List<FeedItem>();
            int oldAnimeListCount = oldAnimeList.Count;
            int newAnimelistCount = newAnimelist.Count;

            if (oldAnimeList != null && newAnimelist != null)
            {
                for (int i = 0; i < newAnimelist.Count; i++)
                {
                    // add anime to returnList if anime realeased
                    if (newAnimelist.ElementAt(i).Date >= oldestAnimeDate.Date) 
                    {
                        returnNewAnims.Add(newAnimelist.ElementAt(i));
                    }
                }           
            }
            return returnNewAnims;
        }


        // todo
        public void DiscordBotMessage(List<FeedItem> value)
        {
            DiscordPingBot discordPingBot = new DiscordPingBot();

        }
    }
}
