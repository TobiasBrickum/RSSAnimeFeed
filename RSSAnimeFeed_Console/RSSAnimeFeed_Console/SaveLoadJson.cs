using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using SimpleFeedReader;
using Newtonsoft.Json;

namespace RSSAnimeFeed_Console
{
    public class SaveLoadJson
    {
        // field
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileFullPath { get; set; }

        // constructor

        /// <summary>
        ///  
        /// </summary>
        /// <param name="fileName"> file.json </param>
        /// <param name="filePath"> folder </param>
        /// <param name="fileFullpath"> foler//file.json </param>
        public SaveLoadJson(string fileName, string filePath, string fileFullPath)
        {
            FileName = fileName;
            FilePath = filePath;
            FileFullPath = fileFullPath;
        }

        /// <summary>
        /// save json file
        /// string json = JsonConvert.SerializeObject(product);
        /// </summary>
        public void SaveJson(List<string> value)
        {
            try
            {
                string jsonAnimeList = JsonConvert.SerializeObject(value);
                File.WriteAllLines(FileFullPath, value);
            }
            catch(Exception e)
            {
                Console.WriteLine("Save Json File Error: " + e.Message);
            }
        }

        public void SaveJson(FeedItem value)
        {
            try
            {
                string jsonAnimeFeedIten = JsonConvert.SerializeObject(value);
            }
            catch (Exception e)
            {
                Console.WriteLine("Save Json File Error: " + e.Message);
            }
        }

        /// <summary>
        /// load json file
        /// Movie m = JsonConvert.DeserializeObject<Movie>(json);
        /// </summary>
        public List<string> LoadJson()
        {
            try
            {
                //string[] temp = File.ReadAllLines(FileFullPath);
                //return temp.ToList<string>();
                List<string> animeList = JsonConvert.DeserializeObject<List<string>>(FileFullPath);
                return animeList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Load Json File Error: " + e.Message);
                return null;
            }
        }

        public IEnumerable<FeedItem> LoadJson()
        {
            try
            {
                //string[] temp = File.ReadAllLines(FileFullPath);
                //return temp.ToList<string>();
                FeedItem animeFeedItem = JsonConvert.DeserializeObject<FeedItem>(FileFullPath);
                return animeFeedItem;
            }
            catch (Exception e)
            {
                Console.WriteLine("Load Json File Error: " + e.Message);
                return null;
            }
        }
        
    }
}
