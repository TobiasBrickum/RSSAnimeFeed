using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleFeedReader;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RSSAnimeFeed_Console
{
    public class SaveLoadFile<T>
    {
        // field
        private char _Seperator = StaticValues.seperator;
        public CreateFilePath File { get; private set; }
        public FileType FileType { get; private set; }

        // constructor

        /// <summary>
        ///  
        /// </summary>
        /// <param name="fileName"> file.json </param>
        /// <param name="filePath"> folder </param>
        /// <param name="fileFullpath"> foler//file.json </param>
        public SaveLoadFile(CreateFilePath value, FileType fileType)
        {
            _Seperator = StaticValues.seperator;
            File = value;
            FileType = fileType;
        }

        /// <summary>
        /// save json file
        /// string json = JsonConvert.SerializeObject(product);
        /// </summary>
        public void SaveFile(T value)
        {
            try
            {
                string temp = null;
                switch (FileType)
                {
                    case FileType.json:
                        {
                            temp = JsonConvert.SerializeObject(value, Formatting.Indented);
                        }
                        break;
                    case FileType.ini:
                        {
                            temp = null;
                        }
                        break;
                }
                System.IO.File.WriteAllText(File.FileFullPath, temp);
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
        public T LoadFile()
        {
            try
            {
                string temp = null;
                switch (FileType)
                {
                    case FileType.json:
                        {
                            temp = System.IO.File.ReadAllText(File.FileFullPath);
                            return JsonConvert.DeserializeObject<T>(temp);
                        }
                        break;
                    case FileType.ini:
                        {
                            return default(T);
                        }
                        break;           
                }
                return default(T);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("Load Jsonfile error: " + e.Message);
                return default(T);
            }
        }

    }
}
