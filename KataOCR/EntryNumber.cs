using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataOCR
{

    public class EntryNumber
    {

        #region Format Constants
        public static string[][,] numberFormats = new string[10][,];
        public static string[,] zeroFormat = new string[3, 3] 
        { 
            {" ","_"," "},
            {"|"," ","|"},
            {"|","_","|"} 
        };
        public static readonly string[,] oneFormat = new string[3, 3] 
        { 
            {" "," "," "}, 
            {" "," ","|"}, 
            {" "," ","|"} 
        };

        public static readonly string[,] twoFormat = new string[3, 3] 
        { 
            {" ","_"," "}, 
            {" ","_","|"}, 
            {"|","_"," "} 
        };
        public static string[,] threeFormat = new string[3, 3] 
        { 
            {" ","_"," "},
            {" ","_","|"},
            {" ","_","|"} 
        };
        public static string[,] fourFormat = new string[3, 3] 
        { 
            {" "," "," "},
            {"|","_","|"},
            {" "," ","|"}
        };
        public static string[,] fiveFormat = new string[3, 3] 
        { 
            {" ","_"," "},
            {"|","_"," "},
            {" ","_","|"} 
        };
        public static string[,] sixFormat = new string[3, 3] 
        { 
            {" ","_"," "},
            {"|","_"," "},
            {"|","_","|"} 
        };
        public static string[,] sevenFormat = new string[3, 3] 
        { 
            {" ","_"," "},
            {" "," ","|"},
            {" "," ","|"} 
        };
        public static string[,] eightFormat = new string[3, 3] 
        { 
            {" ","_"," "},
            {"|","_","|"},
            {"|","_","|"} 
        };
        public static string[,] nineFormat = new string[3, 3] 
        { 
            {" ","_"," "},
            {"|","_","|"},
            {" ","_","|"} 
        };

        #endregion

        private string[,] rawValue;
        public string[,] RawValue
        {

            get
            {

                return rawValue;

            }

            set
            {
                rawValue = value;
                if (ValidateRawValue(value))
                {
                    parsedValue = ParseRawValue(value);
                }
                else
                    parsedValue = -1;

            }

        }

        private int parsedValue;
        public int ParsedValue
        {

            get
            {

                return parsedValue;

            }

        }

        public EntryNumber(string[,] RawValue)
        {
            numberFormats = new string[10][,]
            { 
                zeroFormat,
                oneFormat,
                twoFormat, 
                threeFormat, 
                fourFormat, 
                fiveFormat, 
                sixFormat, 
                sevenFormat, 
                eightFormat, 
                nineFormat
            };

            this.RawValue = RawValue;

        }


        public bool ValidateRawValue(string[,] RawValue)
        {
            if (RawValue == null || RawValue.GetLength(0) != 3 || RawValue.GetLength(1) != 3)
                return false;
            else
                return true;
        }

        public int ParseRawValue(string[,] RawValue)
        {
            bool areEqual;
           
            for (int format = 0; format < numberFormats.GetLength(0); format++)
            {
               areEqual = isUnParsedValueEqualToAFormat(RawValue, format);
               if (areEqual)
                   return format;
            }
            return -1;
        }
        private bool isUnParsedValueEqualToAFormat(string[,] RawValue, int format)
        {
            bool areEqual = true;
            for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        if (RawValue[x, y] == numberFormats[format][x, y])
                        { }
                        else
                        {
                            areEqual = false;
                        }
                    }
                }
            return areEqual;
        }
        
    }
}