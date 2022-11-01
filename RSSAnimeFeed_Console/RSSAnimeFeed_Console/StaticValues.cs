using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace RSSAnimeFeed_Console
{
    public class StaticValues
    {
        // field
        public static readonly char Seperator;

        // constructor
        static StaticValues()
        {
            Seperator = Path.DirectorySeparatorChar;
        }
    }
}
