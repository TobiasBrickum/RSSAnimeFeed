using SimpleFeedReader;

namespace RSSAnimeFeed_Console
{
    public class ViewInConsole
    {
        public static void ViewException(Exception e, string exceptionMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Error.WriteLine("\n Create File error: " + e.Message);
            Console.Error.WriteLine("\n InnerException:\n" + e.InnerException);
            Console.ForegroundColor = StaticValues.ConsoleColorForeground;
            Console.BackgroundColor = StaticValues.ConsoleColorBackground;
        }

        /*
        public static void ViewGeneric<T>(T value)
        {
            string delimiter = "#######################################################################################################################";
            Console.WriteLine("\n\n\t" + delimiter);
            foreach (Object x in value)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("\t" + delimiter);
        }
        */

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
