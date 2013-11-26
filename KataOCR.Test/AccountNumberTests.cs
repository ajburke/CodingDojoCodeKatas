using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataOCR.Test
{
    /// <summary>
    /// Summary description for AccountNumberTest
    /// </summary>
    [TestClass]
    public class AccountNumberTests
    {

        List<string> testLines = new List<string>();
        AccountNumber CUT;
        EntryNumber e1, e2, e3, e4, e5, e6, e7, e8, e9;

        [TestInitialize]
        public void Initialize()
        {
            string line1 = "    _  _     _  _  _  _  _ \r\n";
            string line2 = "  | _| _||_||_ |_   ||_||_|\r\n";
            string line3 = "  ||_  _|  | _||_|  ||_| _|\r\n";
            string line4 = "                           \r\n";

            testLines.Add(line1);
            testLines.Add(line2);
            testLines.Add(line3);
            testLines.Add(line4);

            CUT = new AccountNumber(testLines);
            string[,] entry1 = new string[3,3]
                    { 
                        {" "," "," "}, 
                        {" "," ","|"}, 
                        {" "," ","|"} 
                    };
            string[,] entry2 = new string[3, 3]
                    { 
                        {" ","_"," "}, 
                        {" ","_","|"}, 
                        {"|","_"," "} 
                    };
            string[,] entry3 = new string[3, 3]
                    { 
                        {" ","_"," "},
                        {" ","_","|"},
                        {" ","_","|"}
                    };
            string[,] entry4 = new string[3, 3]
                    { 
                        {" "," "," "},
                        {"|","_","|"},
                        {" "," ","|"}
                    };
            string[,] entry5 = new string[3, 3]
                    { 
                        {" ","_"," "},
                        {"|","_"," "},
                        {" ","_","|"} 
                    };
            string[,] entry6 = new string[3, 3]
                    { 
                        {" ","_"," "},
                        {"|","_"," "},
                        {"|","_","|"} 
                    };
            string[,] entry7 = new string[3, 3]
                    { 
                        {" ","_"," "},
                        {" "," ","|"},
                        {" "," ","|"} 
                    };
            string[,] entry8 = new string[3, 3]
                    { 
                        {" ","_"," "},
                        {"|","_","|"},
                        {"|","_","|"}  
                    };
            string[,] entry9 = new string[3, 3]
                    { 
                        {" ","_"," "},
                        {"|","_","|"},
                        {" ","_","|"} 
                    };
            e1 = new EntryNumber(entry1);
            e2 = new EntryNumber(entry2);
            e3 = new EntryNumber(entry3);
            e4 = new EntryNumber(entry4);
            e5 = new EntryNumber(entry5);
            e6 = new EntryNumber(entry6);
            e7 = new EntryNumber(entry7);
            e8 = new EntryNumber(entry8);
            e9 = new EntryNumber(entry9);
        }

        [TestMethod]
        public void ValidateAndRepairConstructorArraySizeTestsRightLength()
        {
            List<string> actualResults = CUT.ValidateAndRepairConstructorArraySize(testLines);
            List<string> expectedResults = testLines;

            Assert.AreEqual(expectedResults[0], actualResults[0]);
            Assert.AreEqual(expectedResults[1], actualResults[1]);
            Assert.AreEqual(expectedResults[2], actualResults[2]);
            Assert.AreEqual(expectedResults[3], actualResults[3]);
        }

        [TestMethod]
        public void ValidateAndRepairConstructorArraySizeTestsTooShort()
        {
            string line1 = "    _  _     _  _  _  _  _\r\n";
            string line2 = "  | _| _||_||_ |_   ||_||_\r\n";
            string line3 = "  ||_  _|  | _||_|  ||_| _\r\n";
            string line4 = "                          \r\n";

            List<string> testLinesTooShort = new List<string>();
            testLinesTooShort.Add(line1);
            testLinesTooShort.Add(line2);
            testLinesTooShort.Add(line3);
            testLinesTooShort.Add(line4);

            line1 = "     _  _     _  _  _  _  _\r\n";
            line2 = "   | _| _||_||_ |_   ||_||_\r\n";
            line3 = "   ||_  _|  | _||_|  ||_| _\r\n";
            line4 = "                           \r\n";

            List<string> testLinesFixed = new List<string>();
            testLinesFixed.Add(line1);
            testLinesFixed.Add(line2);
            testLinesFixed.Add(line3);
            testLinesFixed.Add(line4);

            CUT = new AccountNumber(testLinesTooShort);

            List<string> actualResults = CUT.ValidateAndRepairConstructorArraySize(testLinesTooShort);
            List<string> expectedResults = testLinesFixed;

            Assert.AreEqual(expectedResults[0], actualResults[0]);
            Assert.AreEqual(expectedResults[1], actualResults[1]);
            Assert.AreEqual(expectedResults[2], actualResults[2]);
            Assert.AreEqual(expectedResults[3], actualResults[3]);
        }

        [TestMethod]
        public void ValidateAndRepairConstructorArraySizeTestsTooLong()
        {
            string line1 = "    _  _     _  _  _  _  _   \r\n";
            string line2 = "  | _| _||_||_ |_   ||_||_|  \r\n";
            string line3 = "  ||_  _|  | _||_|  ||_| _|  \r\n";
            string line4 = "                             \r\n";

            List<string> testLinesTooShort = new List<string>();
            testLinesTooShort.Add(line1);
            testLinesTooShort.Add(line2);
            testLinesTooShort.Add(line3);
            testLinesTooShort.Add(line4);

            line1 = "    _  _     _  _  _  _  _ \r\n";
            line2 = "  | _| _||_||_ |_   ||_||_|\r\n";
            line3 = "  ||_  _|  | _||_|  ||_| _|\r\n";
            line4 = "                           \r\n";

            List<string> testLinesFixed = new List<string>();
            testLinesFixed.Add(line1);
            testLinesFixed.Add(line2);
            testLinesFixed.Add(line3);
            testLinesFixed.Add(line4);

            CUT = new AccountNumber(testLinesTooShort);

            List<string> actualResults = CUT.ValidateAndRepairConstructorArraySize(testLinesTooShort);
            List<string> expectedResults = testLinesFixed;

            Assert.AreEqual(expectedResults[0], actualResults[0]);
            Assert.AreEqual(expectedResults[1], actualResults[1]);
            Assert.AreEqual(expectedResults[2], actualResults[2]);
            Assert.AreEqual(expectedResults[3], actualResults[3]);
        }

        [TestMethod]
        public void ValidateAndRepairConstructorArraySizeTestsTooFewLines()
        {
            string line1 = "    _  _     _  _  _  _  _   \r\n";
            string line2 = "  | _| _||_||_ |_   ||_||_|  \r\n";
            string line3 = "  ||_  _|  | _||_|  ||_| _|  \r\n";

            List<string> testLinesTooShort = new List<string>();
            testLinesTooShort.Add(line1);
            testLinesTooShort.Add(line2);
            testLinesTooShort.Add(line3);

            line1 = "    _  _     _  _  _  _  _ \r\n";
            line2 = "  | _| _||_||_ |_   ||_||_|\r\n";
            line3 = "  ||_  _|  | _||_|  ||_| _|\r\n";
            string line4 = "                           \r\n";

            List<string> testLinesFixed = new List<string>();
            testLinesFixed.Add(line1);
            testLinesFixed.Add(line2);
            testLinesFixed.Add(line3);
            testLinesFixed.Add(line4);

            CUT = new AccountNumber(testLinesTooShort);

            List<string> actualResults = CUT.ValidateAndRepairConstructorArraySize(testLinesTooShort);
            List<string> expectedResults = testLinesFixed;

            Assert.AreEqual(expectedResults[0], actualResults[0]);
            Assert.AreEqual(expectedResults[1], actualResults[1]);
            Assert.AreEqual(expectedResults[2], actualResults[2]);
            Assert.AreEqual(expectedResults[3], actualResults[3]);
        }

        [TestMethod]
        public void ParseLinesIntoEntryNumbersTest()
        {
            CUT.ParseLinesIntoEntryNumbers(testLines);
            EntryNumber[] actualResults = CUT.Numbers;
            EntryNumber[] expectedResults = new EntryNumber[9]
            { 
                e1,
                e2,
                e3,
                e4,
                e5,
                e6,
                e7,
                e8,
                e9
            };

            Assert.AreEqual(expectedResults[0].ParsedValue, actualResults[0].ParsedValue);
            Assert.AreEqual(expectedResults[1].ParsedValue, actualResults[1].ParsedValue);
            Assert.AreEqual(expectedResults[2].ParsedValue, actualResults[2].ParsedValue);
            Assert.AreEqual(expectedResults[3].ParsedValue, actualResults[3].ParsedValue);
            Assert.AreEqual(expectedResults[4].ParsedValue, actualResults[4].ParsedValue);
            Assert.AreEqual(expectedResults[5].ParsedValue, actualResults[5].ParsedValue);
            Assert.AreEqual(expectedResults[6].ParsedValue, actualResults[6].ParsedValue);
            Assert.AreEqual(expectedResults[7].ParsedValue, actualResults[7].ParsedValue);
            Assert.AreEqual(expectedResults[8].ParsedValue, actualResults[8].ParsedValue);

        }

        [TestMethod]
        public void UpdateIDTest()
        {
            string actualResults = CUT.ID;
            string expectedResults = "123456789";

            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void ValidIsValidAccountTest()
        {
            bool actualResults = CUT.IsValidAccount();
            bool expectedResults = true;

            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void InvalidIsValidAccountTest()
        {
            string line1 = " _  _     _  _        _  _ \r\n";
            string line2 = "|_ |_ |_| _|  |  ||_||_||_ \r\n";
            string line3 = "|_||_|  | _|  |  |  | _| _|\r\n";
            string line4 = "                           \r\n";

            testLines[0] = line1;
            testLines[1] = line2;
            testLines[2] = line3;
            testLines[3] = line4;

            CUT = new AccountNumber(testLines);

            bool actualResults = CUT.IsValidAccount();
            bool expectedResults = false;

            Assert.AreEqual(expectedResults, actualResults);
        }

        [TestMethod]
        public void ToStringTest()
        {
            string actualResult = CUT.ToString();
            string expectedResult = "123456789";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void IllegibleNumbersToStringTest()
        {
            string line1 = " _  _     _  _        _  _ \r\n";
            string line2 = "|_ |_ |_| _|  |  ||_||_||_ \r\n";
            string line3 = "|_ |_|  ||_|  |  |  | _| _|\r\n";
            string line4 = "                           \r\n";

            testLines[0] = line1;
            testLines[1] = line2;
            testLines[2] = line3;
            testLines[3] = line4;

            CUT = new AccountNumber(testLines);

            string actualResult = CUT.ToString();
            string expectedResult = "?64?71495";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
