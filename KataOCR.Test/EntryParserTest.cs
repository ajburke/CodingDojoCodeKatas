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
        public void OpenAndReadAndCloseFileTest()
        {
            string fileContents = CUT.OpenAndReadAndCloseFile(filePath);
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
        public void GatherLinesIntoListTest()
        {
            List<string> whatIsActuallyInTheFile = CUT.GatherLinesIntoList(filePath);
            List<string> whatShouldBeInTheFile = new List<string>();
            whatShouldBeInTheFile.Add("    _  _     _  _  _  _  _ \r\n");
            whatShouldBeInTheFile.Add("  | _| _||_||_ |_   ||_||_|\r\n");
            whatShouldBeInTheFile.Add("  ||_  _|  | _||_|  ||_| _|\r\n");
            whatShouldBeInTheFile.Add("                           \r\n");
            whatShouldBeInTheFile.Add(" _  _  _  _  _  _  _  _  _ \r\n");
            whatShouldBeInTheFile.Add("| || || || || || || || || |\r\n");
            whatShouldBeInTheFile.Add("|_||_||_||_||_||_||_||_||_|\r\n");
            whatShouldBeInTheFile.Add("                           \r\n");

            Assert.AreEqual(whatShouldBeInTheFile[0], whatIsActuallyInTheFile[0]);
            Assert.AreEqual(whatShouldBeInTheFile[1], whatIsActuallyInTheFile[1]);
            Assert.AreEqual(whatShouldBeInTheFile[2], whatIsActuallyInTheFile[2]);
            Assert.AreEqual(whatShouldBeInTheFile[3], whatIsActuallyInTheFile[3]);
            Assert.AreEqual(whatShouldBeInTheFile[4], whatIsActuallyInTheFile[4]);
            Assert.AreEqual(whatShouldBeInTheFile[5], whatIsActuallyInTheFile[5]);
            Assert.AreEqual(whatShouldBeInTheFile[6], whatIsActuallyInTheFile[6]);
            Assert.AreEqual(whatShouldBeInTheFile[7], whatIsActuallyInTheFile[7]);
        }
        /*
        [TestMethod]
        public void SplitLinesIntoAccountNumbersListTest()
        {
            List<string> lines = CUT.GatherLinesIntoList(filePath);
            List<AccountNumber> actualResults = CUT.SplitLinesIntoAccountNumbersList(lines);

            List<AccountNumber> expectedResults = new List<AccountNumber>();

            //expectedResults.Add();

        }
        */
    }
    
}
