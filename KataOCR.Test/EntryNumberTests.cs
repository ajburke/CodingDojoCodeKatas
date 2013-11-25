using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KataOCR.Test
{
    /// <summary>
    /// Summary description for EntryNumberTests
    /// </summary>
    [TestClass]
    public class EntryNumberTests
    {
        EntryNumber CUT;
        string[,] testValue;

        [TestInitialize]
        public void Initialize()
        {
            testValue = new string[3,3]
            {
                {" ","_"," "},
                {"|","_","|"},
                {"|","_","|"}
            };
            CUT = new EntryNumber(testValue);
        }

        [TestMethod]
        public void ValidateRawValueTestValidRawValue()
        {
            bool actualValue = CUT.ValidateRawValue(testValue);
            bool expectedValue = true;
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void ValidateRawValueTestNullRawValue()
        {
            testValue = null;
            bool actualValue = CUT.ValidateRawValue(testValue);
            bool expectedValue = false;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void ValidateRawValueTestTooSmallArray()
        {
            string[,] smallValue = new string[2,3]
            {
                {" "," "," "},
                {" "," "," "}
            };
            bool actualValue = CUT.ValidateRawValue(smallValue);
            bool expectedValue = false;

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void ValidateRawValueTestTooLargeArray()
        {
            string[,] largeValue = new string[4, 3]
            {
                {" "," "," "},
                {" "," "," "},
                {" "," "," "},
                {" "," "," "}
            };
            bool actualValue = CUT.ValidateRawValue(largeValue);
            bool expectedValue = false;

            Assert.AreEqual(expectedValue, actualValue);
        }
        [TestMethod]
        public void ParseRawValueTestOne()
        {
            string[,] testValueOne = new string[3, 3]   
            { 
                {" "," "," "}, 
                {" "," ","|"}, 
                {" "," ","|"} 
            };
            int actualValue = CUT.ParseRawValue(testValueOne);
            int expectedValue = 1;

            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void ParseRawValueTestTwo()
        {
            string[,] testValueTwo = new string[3,3]
            { 
                {" ","_"," "}, 
                {" ","_","|"}, 
                {"|","_"," "} 
            };
            int actualValue = CUT.ParseRawValue(testValueTwo);
            int expectedValue = 2;

            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void ParseRawValueTestThree()
        {
            string[,] testValueThree = new string[3,3]
            { 
                {" ","_"," "},
                {" ","_","|"},
                {" ","_","|"} 
            };
            int actualValue = CUT.ParseRawValue(testValueThree);
            int expectedValue = 3;

            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void ParseRawValueTestFour()
        {
            string[,] testValueFour = new string[3,3]
            { 
                {" "," "," "},
                {"|","_","|"},
                {" "," ","|"}
            };
            int actualValue = CUT.ParseRawValue(testValueFour);
            int expectedValue = 4;

            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void ParseRawValueTestFive()
        {
            string[,] testValueFive = new string[3,3]
            { 
                {" ","_"," "},
                {"|","_"," "},
                {" ","_","|"} 
            };
            int actualValue = CUT.ParseRawValue(testValueFive);
            int expectedValue = 5;

            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void ParseRawValueTestSix()
        {
            string[,] testValueSix = new string[3,3]
            { 
                {" ","_"," "},
                {"|","_"," "},
                {"|","_","|"} 
            };
            int actualValue = CUT.ParseRawValue(testValueSix);
            int expectedValue = 6;

            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void ParseRawValueTestSeven()
        {
            string[,] testValueSeven = new string[3,3]
            { 
                {" ","_"," "},
                {" "," ","|"},
                {" "," ","|"} 
            };
            int actualValue = CUT.ParseRawValue(testValueSeven);
            int expectedValue = 7;

            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void ParseRawValueTestEight()
        {
            string[,] testValueEight = new string[3,3]
            { 
                {" ","_"," "},
                {"|","_","|"},
                {"|","_","|"} 
            };
            int actualValue = CUT.ParseRawValue(testValueEight);
            int expectedValue = 8;

            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void ParseRawValueTestNine()
        {
            string[,] testValueNine = new string[3,3]
            { 
                {" ","_"," "},
                {"|","_","|"},
                {" ","_","|"} 
            };
            int actualValue = CUT.ParseRawValue(testValueNine);
            int expectedValue = 9;

            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void ParseRawValueTestZero()
        {
            string[,] testValueZero = new string[3,3]
            { 
                {" ","_"," "},
                {"|"," ","|"},
                {"|","_","|"} 
            };
            int actualValue = CUT.ParseRawValue(testValueZero);
            int expectedValue = 0;

            Assert.AreEqual(expectedValue, actualValue);

        }
        [TestMethod]
        public void ParseRawValueTestInvalid()
        {
            string[,] testValueInvalid = new string[3,3]
             { 
                {" ","_"," "},
                {"|"," "," "},
                {"|","_","|"} 
            };
            int actualValue = CUT.ParseRawValue(testValueInvalid);
            int expectedValue = -1;

            Assert.AreEqual(expectedValue, actualValue);

        }


    }
}
