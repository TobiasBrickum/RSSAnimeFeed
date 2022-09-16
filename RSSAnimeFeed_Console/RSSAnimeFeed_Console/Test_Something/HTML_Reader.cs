using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RSSAnimeFeed_Console.Test_Something
{
    public class HTML_Reader
    {
        // field
        public string inputFileName { get; private set; }
        public string outputFileName { get; private set; }

        public string inputFilePath { get; private set; }
        public string outputFilePath { get; private set; }
        public string osPathSeperator { get; private set; }

        // constructor
        public HTML_Reader(string pinputFileName, string poutputFileName, string pinputFilePath, string poutputFilePath)
        {
            // fill field prpperties
            inputFileName = pinputFileName;
            outputFileName = poutputFileName;
            inputFilePath = PathSeperatorHelper(inputFileName, pinputFilePath);
            outputFilePath = PathSeperatorHelper(outputFileName, poutputFilePath);
            osPathSeperator = Path.DirectorySeparatorChar.ToString();

            // check user input is empty or null
            List<string> checkUserInputs = new List<string>();
            checkUserInputs.Add(inputFileName);
            checkUserInputs.Add(outputFileName);
            checkUserInputs.Add(inputFilePath);
            checkUserInputs.Add(outputFilePath);
            checkUserInputs.Add(osPathSeperator);
            checkIsNullOrEmpty(checkUserInputs);
        }

        /// <summary>
        /// check user input empty or null
        /// </summary>
        /// <param name="checkStrings"></param>
        /// <exception cref="Exception"></exception>
        private void checkIsNullOrEmpty(List<string> checkStrings)
        {
            for (int i = 0; i < checkStrings.Count; i++)
            {
                if (checkStrings.ElementAt(i) == null || checkStrings.ElementAt(i).Length <= 0)
                {
                    // TODO throw exception
                    throw new Exception("Empty Name, Valure or Syntac in: " + checkStrings.ElementAt(i)); // add variable name
                }
            }
        }


        //  TODO trhow exceptio
        /// <summary>
        /// make sure every body os use correct file path
        /// </summary>
        /// <param name="fullPath"> path from randomly os </param>
        /// <returns> parameter path works now under al os</returns>
        public string PathSeperatorHelper(string fileName, string filePath)
        {
            string retPath = filePath + osPathSeperator + fileName;
            //@"C:\\Users\\Shiki\\Desktop\\DS4Windows_3.0.18_x64     //test patch
            List<string> toChange = new List<string>();
            toChange.Add(@"//");
            toChange.Add(@"\\");
            toChange.Add(@"\");
            toChange.Add(@"/");

            for (int i = 0; i < toChange.Count; i++)
            {
                retPath = retPath.Replace(toChange.ElementAt(i), osPathSeperator);
            }

            return retPath;
        }

        /// <summary>
        /// Read file line by line and save tham in a String list
        /// </summary>
        /// <returns></returns>
        public List<string> ReadInputFile()
        {
            try
            {
                StreamReader streamReader = new StreamReader(inputFilePath);
                List<string> lreadLine = new List<string>();

                while (streamReader.ReadLine() != null)
                {
                    lreadLine.Add(streamReader.ReadLine());
                }

                Console.WriteLine("Readed html input lines: " + lreadLine.Count);
                return lreadLine;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }


        /// <summary>
        /// Create or overide a file with values from the method paramater list.
        /// </summary>
        /// <param name="toWrite"></param>
        public void WriteInputFile(List<string> values)
        {
            try
            {
                //string allLines = "";
                for (int i = 0; i < values.Count; i++)
                {
                    File.WriteAllText(outputFilePath, values.ElementAt(i));

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
