// See https://aka.ms/new-console-template for more information
using RSSAnimeFeed_Console.UnitTest.Test;
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
        }

        public static void UnitTestBanc()
        {
            Banc banc = new Banc();


        }
    }
}


