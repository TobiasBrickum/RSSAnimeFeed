using SimpleFeedReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HTML_Downlaod_Konsole
{
    public enum enumWeekDay : int{ Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    public class RSSLibarie
    {
        /// <summary>
        /// https://github.com/RobThree/SimpleFeedReader
        /// Read RSS Recently Added Anime Videos from Crunchycroll


        /// </summary>+
        public void ReadNewAnimeTitleRss()
        {
            try
            {
                string rssUrl = "http://feeds.feedburner.com/crunchyroll/rss/anime?lang=deDE";
                Console.WriteLine("Read rss from link: " + rssUrl);

                FeedReader feedReader = new FeedReader();
                IEnumerable<FeedItem> rssFeedItems = feedReader.RetrieveFeed(rssUrl);

                // save readed anime titles
                List<string> rssAnimeTitle = new List<string>();
                foreach (FeedItem feedItem in rssFeedItems)
                {
                    Console.WriteLine($"{feedItem.Date.ToString("g")}\t{feedItem.Title}");
                    //Console.WriteLine(feedItem.Title);
                    //rssAnimeTitle.Add(feedItem.Title);    
                }
                viewListInConsole(rssAnimeTitle);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
