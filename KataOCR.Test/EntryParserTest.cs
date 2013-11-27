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
    
    [DeploymentItem(@".\InputOutputFiles\OCR.txt")]
    [TestClass]
    public class EntryParserTest
    {
        private EntryParser CUT;
        private string filePath;


        [TestInitialize]
        public void Initialize()
        {
            filePath = Directory.GetCurrentDirectory() + "./OCR.txt";
            CUT = new EntryParser(filePath);
            
        }

        [TestMethod]
        public void SplitLinesIntoAccountNumbersListTest()
        {
            List<string> lines = File.ReadAllLines(filePath).ToList();
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
