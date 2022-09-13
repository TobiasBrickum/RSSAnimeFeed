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
                slJasonGeneric.SaveJson(newSaveAnimeTitle);     // if not exist create new anime title file
            }
            else
            {
                oldLoadAnimeTitle = slJasonGeneric.LoadJson();  // load old anime title file
            }

            pingUpcomingAnimeTitle = CompareOldNewAnimeTitle(oldLoadAnimeTitle, newSaveAnimeTitle);    // create ping only the newest anime title
            slJasonGeneric.SaveJson(newSaveAnimeTitle);                                                // update old anime title file 

            slJasonGeneric = new SaveLoadJsonGeneric<List<FeedItem>>(npingUpcomingAnimeTitleFile, pingUpcomingAnimeTitleFilePath, pingUpcomingAnimeTitleFileFullPath);
            slJasonGeneric.SaveJson(pingUpcomingAnimeTitle);                                           // save only the newest anime title 


            ViewListFeedIitle(pingUpcomingAnimeTitle, "to ping anime title: ");
            ViewListFeedIitle(newSaveAnimeTitle, "all new anime title");

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

                List<FeedItem> feedList = new List<FeedItem>(); // create list with full rss feed items 
                foreach (FeedItem feedItem in rssFeedItems)
                {
                    feedList.Add(feedItem);
                }

                return feedList;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return null;
            }             
        }


        // todo
        public List<FeedItem> CompareOldNewAnimeTitle(List<FeedItem> oldAnimeList, List<FeedItem> newAnimelist)
        {
            // delete the three first items on old anime list, to see what save in ping aniem file
            oldAnimeList.RemoveRange(0, 2);

            List<FeedItem> returnNewAnims = new List<FeedItem>();

            int oldAnimeListCount = oldAnimeList.Count;
            int newAnimelistCount = newAnimelist.Count;

            if (oldAnimeList != null && newAnimelist != null)    // 
            {
                FeedItem newestOldAnimeLIstDay = new FeedItem();
                newestOldAnimeLIstDay = oldAnimeList.ElementAt(0);

                for (int i = 0; i < newAnimelist.Count; i++)
                {
                    
                    // add anime to list if newer date
                    if (newAnimelist.ElementAt(i).Date > newestOldAnimeLIstDay.Date) 
                    {
                        returnNewAnims.Add(newAnimelist.ElementAt(i));
                    }

                    // add anime to list if date same but diferent name
                    if(newAnimelist.ElementAt(i).Date == newestOldAnimeLIstDay.Date)
                    {
                        string currentAnimeTitle = newAnimelist.ElementAt(i).Title;

                        foreach (FeedItem oldAnimeTitle in oldAnimeList)
                        {
                            if(oldAnimeTitle.Title == currentAnimeTitle)
                            {
                                returnNewAnims.Add(newAnimelist.ElementAt(i));
                            }
                        }
                    }

                }

                // reverse anime list, so that the newest stay on top
                if(returnNewAnims.Count > 1)
                {
                    returnNewAnims.Reverse();
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
