using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using RSSAnimeFeed_Console;

namespace RSSAnimeFeed_Console_UnitTest.UnitTest.RssFeed
{
    [TestFixture] // recomend for NUnit.Framework
    public class FakeSaveLoadFile
    {
        // field


        // constructor
        public FakeSaveLoadFile()
        {
        }

        public void ClearUnitTestFolder()
        {
            string path = "UnitTest";
            if (Directory.Exists(path))
            {
                Directory.Delete(path);
            }
            Directory.CreateDirectory(path);
        }

        [Test]
        public void WrongFielType()
        {
            // arrange
            string fakeFile = "fakeFile.fake";
            string fakeFilePath = "UnitTest";
            string fakeFileFullPath = fakeFilePath + StaticValues.seperator + fakeFile;
            CreateFilePath unitTest = new CreateFilePath(EFileType.UnitTest, fakeFile, fakeFilePath, fakeFileFullPath);
            

            ClearUnitTestFolder();
            using (File.Create(unitTest.FilePath)) ;
            SaveLoadFile<string> saveLoadFiley = new SaveLoadFile<string>(unitTest);

            // act
            saveLoadFiley.SaveFile("Value");

            // assert
            Assert.That(saveLoadFiley, Is.EqualTo(new Exception("Wrong Filetyp")));
            //throw new Exception("Wrong Filetyp");
        }


    }
}
