using HTML_Downlaod_Konsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RSSAnimeFeed_Console
{
    public class DoSomethingTestCode
    {
        /// <summary>
        /// Read HTML file...
        /// </summary>
        public void Test_HTML_ReadInput_WriteInput()
        {
            string inputFileName = "https __www.crunchyroll.com_de_fuuto-pi.htm";
            string outputFileName = "output_file_from_readed_input_file.txt";
            string bothFilePath = "TestFiles";
            HTML_Reader readHzml = new HTML_Reader(inputFileName, outputFileName, bothFilePath, bothFilePath);

            List<string> readedInputFile = readHzml.ReadInputFile();
            readHzml.WriteInputFile(readedInputFile);
        }


        public void Test_HTML_Downlaod_Picture()
        {
            String anime = "https://cdn.discordapp.com/attachments/693433288987246642/1008342444456288296/";

            string remoteUri = anime;
            string fileName = "unknown.png", myStringWebResource = null;
            //https://cdn.discordapp.com/attachments/693433288987246642/1008342444456288296/unknown.png
            // Create a new WebClient instance.
            WebClient myWebClient = new();


            // Concatenate the domain with the Web resource filename.
            myStringWebResource = remoteUri + fileName;
            Console.WriteLine("Downloading File \"{0}\" from \"{1}\" .......\n\n", fileName, myStringWebResource);

            // Download the Web resource and save it into the current filesystem folder.
            myWebClient.DownloadFile(myStringWebResource, fileName);
            Console.WriteLine("Successfully Downloaded File \"{0}\" from \"{1}\"", fileName, myStringWebResource);
            //Console.WriteLine("\nDownloaded file saved in the following file system folder:\n\t" + Application.StartupPath);
        }


        public void TestDownloadHTML()
        {
            string animeUrl = "https://www.crunchyroll.com/de/fuuto-pi";
            //animeUrl = "https://google.de";
            string downlaodName = "c.html";

            WebClient wClient = new WebClient();
            wClient.Headers.Add("User-Agent: Other");   //that is the simple line!
            wClient.DownloadFile(animeUrl, downlaodName);

            /*
            string strSource = wClient.DownloadString("https://www.crunchyroll.com/de/fuuto-pi");
            StreamWriter writer = new StreamWriter("google.html");
            writer.Write(strSource);
            writer.Close();
            */
            Console.WriteLine("\n\n wurde einfach so aufgerunfen");
        }


        public void TryStackOvebrflow()
        {
            string animeUrl = "https://www.crunchyroll.com/de/fuuto-pi";
            string downlaodHTMLPath = "c.html";

            WebClient objWebClient = new WebClient();
            Uri uriWebClient = new Uri(animeUrl);
            objWebClient.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            //objWebClient.Headers.Add("Other;");
            //objWebClient.Headers.Add("ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;");
            //objWebClient.Headers.Add("Content-Type", "application / zip, application / octet - stream");
            //objWebClient.Headers.Add("Accept-Encoding", "gzip,deflate,sdch");
            //objWebClient.Headers.Add("Referer", "http://Something");
            //objWebClient.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8");
            objWebClient.DownloadFile(uriWebClient, downlaodHTMLPath);
        }
    }
}
