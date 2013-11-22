using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace KataOCR.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class EntryParserTest
    {
        private EntryParser CUT;
        private string filePath;

        public EntryParserTest()
        {
           
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize]
        public void Initialize()
        {
            CUT = new EntryParser();
            filePath = "C:\\Users\\alexander.burke\\Desktop\\CodeKata\\OCR";
        }

        [TestMethod]
        public void OpenFileTest()
        {
            string fileContents = CUT.OpenAndReadFile(filePath);
            string whatShouldBeInTheFile = "    _  _     _  _  _  _  _ \r\n" +
                                           "  | _| _||_||_ |_   ||_||_|\r\n" +
                                           "  ||_  _|  | _||_|  ||_| _|\r\n" +
                                           "                           \r\n" +
                                           " _  _  _  _  _  _  _  _  _ \r\n" +
                                           "| || || || || || || || || |\r\n" +
                                           "|_||_||_||_||_||_||_||_||_|\r\n" +
                                           "                           \r\n";
            Assert.AreEqual( whatShouldBeInTheFile, fileContents);
        }

        [TestMethod]
        public void GatherEntriesIntoListTest()
        {
            string fileRawContents = CUT.OpenAndReadFile(filePath);
            List<string> whatIsActuallyInTheFile = CUT.GatherEntriesIntoList(filePath);
            List<string> whatShouldBeInTheFile = new List<string>();
            whatShouldBeInTheFile.Add("    _  _     _  _  _  _  _ \r\n" +
                                      "  | _| _||_||_ |_   ||_||_|\r\n" +
                                      "  ||_  _|  | _||_|  ||_| _|\r\n" +
                                      "                           \r\n");
            whatShouldBeInTheFile.Add(" _  _  _  _  _  _  _  _  _ \r\n" +
                                      "| || || || || || || || || |\r\n" +
                                      "|_||_||_||_||_||_||_||_||_|\r\n" +
                                      "                           \r\n");

            Assert.AreEqual(whatShouldBeInTheFile[0], whatIsActuallyInTheFile[0]);
            Assert.AreEqual(whatShouldBeInTheFile[1], whatIsActuallyInTheFile[1]);
        }

        [TestMethod]
        public void ConvertEntryListIntoAccountArrays(List<string> entries)
        {

        }
    }

}
