// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace RSSAnimeFeed_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shiki say: Hello, World!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            CheckNewAnimeTitle();
        }

        public static void CheckNewAnimeTitle()
        {
            // delete cach
            //DeleteCachFiles();

            // drove drove
            RSSLibarie rssrReader = new RSSLibarie();
            //rssrREader.ReadNewAnimeTitleRss();
            rssrReader.CheckNewAnimes();
        }

        // old test code
        public static void TestSomethingOld()
        {
            DoSomethingTestCode testCode = new DoSomethingTestCode();
            testCode.TryStackOvebrflow();
            testCode.Test_HTML_ReadInput_WriteInput();
        }

        public static void DeleteCachFiles()
        {
            string directoryName = "Rss_Feed_Files";
            try
            {
                if(Directory.Exists(directoryName) == true)
                {
                    Directory.Delete(directoryName, true);
                }
                Directory.CreateDirectory(directoryName);
            }
            catch(Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }
    }

}

