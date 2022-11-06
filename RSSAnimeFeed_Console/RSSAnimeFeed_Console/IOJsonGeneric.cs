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
        private char _Seperator = StaticValues.seperator;
        public CreateFilePath File { get; private set; }

        // constructor

        /// <summary>
        ///  
        /// </summary>
        /// <param name="fileName"> file.json </param>
        /// <param name="filePath"> folder </param>
        /// <param name="fileFullpath"> foler//file.json </param>
        public IOJsonGeneric(CreateFilePath value)
        {
            _Seperator = StaticValues.seperator;
            File = value;
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
                System.IO.File.WriteAllText(File.FileFullPath, jsonValue);
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
                string jsonValue = System.IO.File.ReadAllText(File.FileFullPath);
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
