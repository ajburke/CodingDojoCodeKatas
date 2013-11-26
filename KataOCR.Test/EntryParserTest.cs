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
            filePath = "C:\\Users\\alexander.burke\\Desktop\\CodeKata\\OCR";
            CUT = new EntryParser(filePath);
            
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

        [TestMethod]
        public void SplitLinesIntoAccountNumbersListTest()
        {
            List<string> lines = CUT.GatherLinesIntoList(filePath);
            List<AccountNumber> actualResults = CUT.SplitLinesIntoAccountNumbersList(lines);

            List<string> expectedResults = new List<string>();

            expectedResults.Add("123456789");
            expectedResults.Add("000000000");

            Assert.AreEqual(expectedResults[0], actualResults[0].ID);
            Assert.AreEqual(expectedResults[1], actualResults[1].ID);

        }

        [TestMethod]
        public void PrintResultsToFileTest()
        {
            string inputFilePath = "C:\\Users\\alexander.burke\\Desktop\\CodeKata\\UseCase3";
            string outputFilePath = "C:\\Users\\alexander.burke\\Desktop\\CodeKata\\UseCase3Results";
            CUT = new EntryParser(inputFilePath);
            CUT.PrintResultsToFile(outputFilePath);


            string actualResults;
            StreamReader outputFileContents = new StreamReader(outputFilePath);
            actualResults = outputFileContents.ReadToEnd();
            
            outputFileContents.Close();

            string expectedResults = "000000051    \r\n" +
                                     "49006771? ILL\r\n" +
                                     "1234?678? ILL\r\n";


            Assert.AreEqual(expectedResults, actualResults);
        }
    }
    
}
