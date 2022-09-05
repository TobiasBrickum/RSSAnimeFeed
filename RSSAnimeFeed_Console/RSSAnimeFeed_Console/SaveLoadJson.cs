using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
        public void SaveJson()
        {
            try
            {
                File abc = new File();
            }
            catch(Exception e)
            {
                Console.WriteLine("Save Json File Error: " + e.Message);
            }
        }

        /// <summary>
        /// load json file
        /// Movie m = JsonConvert.DeserializeObject<Movie>(json);
        /// </summary>
        public void LoadJson()
        {
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine("Load Json File Error: " + e.Message);
            }
        }
    }
}
