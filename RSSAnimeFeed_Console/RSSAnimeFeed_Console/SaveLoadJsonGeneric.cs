using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleFeedReader;

namespace RSSAnimeFeed_Console
{
    public class SaveLoadJsonGeneric<T>
    {
        // field
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public string FileFullPath { get; private set; }

        // constructor

        /// <summary>
        ///  
        /// </summary>
        /// <param name="fileName"> file.json </param>
        /// <param name="filePath"> folder </param>
        /// <param name="fileFullpath"> foler//file.json </param>
        public SaveLoadJsonGeneric(string fileName, string filePath, string fileFullPath)
        {
            CeckPath(fileName, filePath, fileFullPath);
        }

        // todo use file seperator for different os users
        private void CeckPath(string fileName, string filePath, string fileFullPath)
        {
            string pathSeperator = "";
            FileName = fileName;
            FilePath = filePath;
            FileFullPath = filePath + fileName;
        }

        // todo use file seperator for different os users
        public static string CeckPathStatic(string fileName, string filePath)
        {
            return filePath + fileName;
        }

        /// <summary>
        /// save json file
        /// string json = JsonConvert.SerializeObject(product);
        /// </summary>
        public void SaveJsonGeneric(T value)
        {
            try
            {
                string jsonValue = JsonConvert.SerializeObject(value);
                File.WriteAllText(FileFullPath, jsonValue);
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
        public T LoadJsonGeneric()
        {
            try
            {
                //string[] temp = File.ReadAllLines(FileFullPath);
                //return temp.ToList<string>();
                return JsonConvert.DeserializeObject<T>(FileFullPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Load Json File Error: " + e.Message);
                return default(T);
            }
        }
    }
}
