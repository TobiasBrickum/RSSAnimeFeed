using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using RSSAnimeFeed_Console_UnitTest.UnitTest.Test;
using RSSAnimeFeed_Console_UnitTest.UnitTest.RssFeed;
using RSSAnimeFeed_Console_UnitTest.UnitTest.BancExample;
using RSSAnimeFeed_Console;

namespace RSSAnimeFeed_Console_UnitTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Unit Test");

            UnitTestBanc();
            //RSSAnimeFeed rss = new RSSAnimeFeed();
        }

        public static void UnitTestBanc()
        {
            Banc banc = new Banc();


        }
    }
}


