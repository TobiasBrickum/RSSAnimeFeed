// See https://aka.ms/new-console-template for more information

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace RSSAnimeFeed_Console
{



    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shiki say: Hello, World!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;

            DeleteCachFiles();
            CheckNewAnimeTitle();

            //TestSaveLoadJsonFiles(); // tested and work
        }

        public static void TestSaveLoadJsonFiles()  // tested and work
        {
            Test_Json productJson = new Test_Json();
            productJson.SetProductJsonConvert();
            productJson.GetProductJsonConvert();
            /*
            char seperator = Path.DirectorySeparatorChar;
            string oldAnimeFile = $"Test.json";
            string oldAnimeFilePath = $"Rss_Feed_Files";
            string oldAnimeFileFullPath = oldAnimeFilePath + seperator + oldAnimeFile;

            SaveLoadJsonGeneric<RSSLibarie> jsonCreator = new SaveLoadJsonGeneric<RSSLibarie>(oldAnimeFile, oldAnimeFilePath, oldAnimeFileFullPath);
            RSSLibarie rss = new RSSLibarie();
            rss.Empty_Propertie = "renamed";
            jsonCreator.SaveJson(rss);


            RSSLibarie jsonLoaded = jsonCreator.LoadJsonAsync();
            Console.WriteLine("loaded json tets file = " + jsonLoaded.Empty_Propertie);
            */
        }

        public static void ViewListInConsole(List<string> value)
        {
            string delimiter = "#######################################################################################################################";
            Console.WriteLine("\n\t" + delimiter);
            foreach (string line in value)
            {
                Console.WriteLine(line);
            }
            Console.WriteLine("\t" + delimiter);
        }

        public static void CheckNewAnimeTitle()
        {
            // delete cach
            //DeleteCachFiles();

            // drove drove
            RSSLibarie rssrReader = new RSSLibarie();
            //rssrREader.ReadNewAnimeTitleRss();
            rssrReader.CheckNewAnimeTitleExist();
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

