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
    public class Product
    {
        public string Name { get; set; }    
        public DateTime ExpiryDate { get; set; }   
        public Double Price { get; set; } 
        public string[] Sizes { get; set; }

        public void Product_Json()
        {
            Product product = new Product();

            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99;
            product.Sizes = new string[] { "Small", "Medium", "Large" };

            string output = JsonConvert.SerializeObject(product);
            //{
            //  "Name": "Apple",
            //  "ExpiryDate": "2008-12-28T00:00:00",
            //  "Price": 3.99,
            //  "Sizes": [
            //    "Small",
            //    "Medium",
            //    "Large"
            //  ]
            //}

            Product deserializedProduct = JsonConvert.DeserializeObject<Product>(output);
        }
    }


    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shiki say: Hello, World!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            //CheckNewAnimeTitle();

            TestSaveLoadJsonFiles();
        }

        public static void TestSaveLoadJsonFiles()
        {
            Product productJson = new Product();
            productJson.Product_Json();
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

