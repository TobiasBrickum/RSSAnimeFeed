using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSAnimeFeed_Console
{
    public class Test_Json
    {

        char seperator = Path.DirectorySeparatorChar;

        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Double Price { get; set; }
        public string[] Sizes { get; set; }

        
        public void SetProductJsonConvert()
        {

            string Test_Json = $"Test_Json.json";
            string Test_JsonPath = $"Rss_Feed_Files";
            string Test_JsonFullPath = Test_JsonPath + seperator + Test_Json;
            SaveLoadJsonGeneric<string> saveLoadJsonGeneric = new SaveLoadJsonGeneric<string>(Test_Json, Test_JsonPath, Test_JsonFullPath);



            Test_Json product = new Test_Json();

            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99;
            product.Sizes = new string[] { "Small", "Medium", "Large" };

            string output = JsonConvert.SerializeObject(product);   
            saveLoadJsonGeneric.SaveJson(output);
            //{
            //  "Name": "Apple",
            //  "ExpiryDate": "2008-12-28T00:00:00",
            //  "Price": 3.99,
            //  "Sizes": [
            //    "Small",
            //    "Medium",
            //    "Large"
            //  ]
            //}

            /*
            Console.WriteLine(output);
            output = saveLoadJsonGeneric.LoadJson("q");
            Console.WriteLine(output);

            Test_Json deserializedProduct = JsonConvert.DeserializeObject<Test_Json>(output);
            Console.WriteLine("json read format: " + deserializedProduct);
            */
        }

        public void GetProductJsonConvert()
        {
            Test_Json product = new Test_Json();

            product.Name = "Apple";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99;
            product.Sizes = new string[] { "Small", "Medium", "Large" };

            string output = JsonConvert.SerializeObject(product);
            //{
            //  "Name": "Apple",
            //  "ExpiryDate": "2008-12-28T00:00:00",
            //  "Price": 3.99,
            //  "Sizes": [
            //    "Small",
            //    "Medium",
            //    "Large"
            //  ]
            //}
        }

    }
}
