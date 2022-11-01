using SimpleFeedReader;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RSSAnimeFeed_Console
{
    public class RssFeedWeebHook
    {
        public RssFeedWeebHook(List<FeedItem> feedItems)
        {

        }

        // Push anime feed discord weebhook 
        public void PushAnimeFeed(List<FeedItem> pingAnimes)
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("\n\tShiki Say: Hello, World! In PushAnimeFeed Method :)");

            var wb = new WebClient();
            var data = new NameValueCollection();
            string url = "";
            data[""] = "";
            data[""] = "";

            var response = wb.UploadValues(url, "POST", data);
        }
    }
}
