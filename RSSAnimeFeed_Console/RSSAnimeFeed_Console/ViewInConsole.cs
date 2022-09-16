using SimpleFeedReader;

namespace RSSAnimeFeed_Console
{
    public class ViewInConsole
    {
        /// <summary>
        /// View String List in Console
        /// </summary>
        /// <param name="value"></param>
        public static void ViewList(List<string> value)
        {
            string delimiter = "#######################################################################################################################";
            Console.WriteLine("\n\n\t" + delimiter);
            foreach (string line in value)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("\t" + delimiter);
        }

        /// <summary>
        /// View FeedItem List in Console
        /// </summary>
        /// <param name="animeList">FeedItem list</param>
        /// <param name="message">String value, what view in console befor view list</param>
        public static void ViewList(List<FeedItem> animeList, string message)
        {
            Console.WriteLine("\n\n\t" + message);
            Console.WriteLine();
            foreach (FeedItem feedItem in animeList)
            {
                Console.WriteLine(feedItem.Date + "\t" + feedItem.Title);
            }
        }
    }
}
