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
        public char Seperator { get; private set; }
        public string FileName { get; private set; }
        public string FilePath { get; private set; }
        public string FileFullPath { get; private set; }

        // constructor

        public SaveLoadJsonGeneric()
        {
            Seperator = Path.DirectorySeparatorChar;
        }

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

        // todo
        private void CeckPath(string fileName, string filePath, string fileFullPath)
        {
            FileName = fileName;
            FilePath = filePath;
            FileFullPath = fileFullPath;
            Seperator = Path.DirectorySeparatorChar;
        }

        // todo
        public void SetNewPathValues(string fileName, string filePath, string fileFullPath)
        {
            FileName = fileName;
            FilePath = filePath;
            FileFullPath = fileFullPath;
        }

        // todo
        public static string GetSeperatorPath()
        {
            return null;
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
                Console.Error.WriteLine("Save Json File Error: " + e.Message);
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
                T ret = JsonConvert.DeserializeObject<T>(jsonValue);
                return ret;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Load Json File Error: " + e.Message);
                return default(T);
            }
        }

    }
}
