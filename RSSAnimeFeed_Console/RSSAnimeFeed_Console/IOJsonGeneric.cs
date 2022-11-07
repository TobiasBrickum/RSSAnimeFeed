using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleFeedReader;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using IniParser;
using IniParser.Model;

namespace RSSAnimeFeed_Console
{
    public class SaveLoadFile<T>
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
        public SaveLoadFile(CreateFilePath value)
        {
            _Seperator = StaticValues.seperator;
            File = value;
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
                switch (File.FileType)
                {
                    case EFileType.Json:
                        {
                            temp = JsonConvert.SerializeObject(value, Formatting.Indented);
                        }
                        break;
                    case EFileType.Ini:
                        {
                            FileIniDataParser parser = new FileIniDataParser();
                            IniData data = parser.ReadFile(File.FileFullPath);
                            data["Global Settings"]["All fine"] = "true";
                            data["Global Settings"]["All dump"] = "false";
                            data["UI"]["fullscreen"] = "true";

                            string useFullScreenStr = data["UI"]["fullscreen"];

                            Console.WriteLine(data.ToString());
                            // useFullScreenStr contains "true"
                            bool useFullScreen = bool.Parse(useFullScreenStr);

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
                switch (File.FileType)
                {
                    case EFileType.Json:
                        {
                            temp = System.IO.File.ReadAllText(File.FileFullPath);
                            return JsonConvert.DeserializeObject<T>(temp);
                        }
                    case EFileType.Ini:
                        {
                            FileIniDataParser parser = new FileIniDataParser();
                            IniData data = parser.ReadFile(File.FileFullPath);
                            
                            Console.WriteLine(data.ToString());
                            //return data.ToString();
                            /*
                            string useFullScreenStr = data["UI"]["fullscreen"];
                            // useFullScreenStr contains "true"
                            bool useFullScreen = bool.Parse(useFullScreenStr);
                            */
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
