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
        public void ParseAccountNumberTest()
        {
            List<string> entries = CUT.GatherEntriesIntoList(filePath);
            int[] whatIsTheResult = CUT.ParseAccountNumber(entries[0]);
            int[] whatShouldBeTheResult = {1,2,3,4,5,6,7,8,9};

            Assert.AreEqual(whatShouldBeTheResult, whatIsTheResult);
        }
    }

}
