using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataOCR
{

    public class AccountNumber
    {
        public const int lineLength = 29;
        public const int numberOfLines = 4;

        public AccountNumber(List<string> Lines)
        {



            //Send 3x3 chunks for parsing

            //numbers[0] = new EntryNumber();

        }

        private EntryNumber[] numbers = new EntryNumber[9];
        public EntryNumber[] Numbers
        {
            get
            {
                return numbers;
            }
            set
            {
                numbers = value;
            }
        }


        public List<string> ValidateAndRepairConstructorArraySize(List<string> lines)
        {
            if (lines.Count == numberOfLines)
            {
                lines = FixLineLength(lines);
                return lines;
                 
            }
            else
            {
                lines = FixNumberOfLines(lines);
                return ValidateAndRepairConstructorArraySize(lines);
            }
            
        }

        private List<string> FixLineLength(List<string> lines)
        {
            for (int i = 0; i < numberOfLines; i++)
            {
                if (lines[i].Length == lineLength)
                { }
                else if (lines[i].Length > lineLength)
                {
                    StringBuilder SB = new StringBuilder();
                    SB.Append(lines[i].Substring(0, lineLength - 2));
                    SB.Append("\r\n");
                    lines[i] = SB.ToString();
                }
                else
                {
                    StringBuilder SB = new StringBuilder();
                    SB.Append(lines[i]);
                    for (int j = lines[i].Length; j < lineLength; j++)
                    {
                        SB.Insert(0, " ");
                    }
                    lines[i] = SB.ToString();
                }
            }
            return lines;
        }

        private List<string> FixNumberOfLines(List<string> lines)
        {
            for (int i = lines.Count; i < numberOfLines; i++)
            {
                lines.Add("                           \r\n");
            }
            return lines;
        }

        public void ParseLinesIntoEntryNumbers(List<string> lines)
        {
            string[,] currentEntry = new string[3,3];
            int numberPosition = 0;
            for (int n = 0; n < numbers.Length; n++)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = numberPosition; y < numberPosition+3; y++)
                    {
                        currentEntry[x, y] = lines[x].Substring(y, 1);
                    }
                }
                numberPosition += 3;
                numbers[n] = new EntryNumber(currentEntry);

            }
        }


        /*
        public override string ToString()
        {

            StringBuilder SB = new StringBuilder();

            //Loop over numbers

            //SB.Append(numbers[0].ParsedValue == -1 ? "?" : Convert.ToString(numbers[0].ParsedValue));

            return SB.ToString();
        }
        */
    }

}