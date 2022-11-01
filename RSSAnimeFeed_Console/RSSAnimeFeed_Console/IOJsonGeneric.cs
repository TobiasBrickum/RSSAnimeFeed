using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleFeedReader;
using Newtonsoft.Json;

namespace RSSAnimeFeed_Console
{
    public class IOJsonGeneric<T>
    {
        // field
        private char _Seperator = StaticValues.Seperator;
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
        public IOJsonGeneric(string fileName, string filePath, string fileFullPath)
        {
            _Seperator = StaticValues.Seperator;
            FileName = fileName;
            FilePath = filePath;
            FileFullPath = fileFullPath;
        }

        /// <summary>
        /// save json file
        /// string json = JsonConvert.SerializeObject(product);
        /// </summary>
        public void SaveJson(T value)
        {
            try
            {
                string jsonValue = JsonConvert.SerializeObject(value, Formatting.Indented);
                File.WriteAllText(FileFullPath, jsonValue);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Create Jsonfile error: " + e.Message);
            }
        }

        /// <summary>
        /// load json file
        /// Movie m = JsonConvert.DeserializeObject<Movie>(json);
        /// </summary>
        public T LoadJson()
        {
            try
            {
                string jsonValue = File.ReadAllText(FileFullPath);
                return JsonConvert.DeserializeObject<T>(jsonValue);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Load Jsonfile error: " + e.Message);
                return default(T);
            }
        }

    }
}
