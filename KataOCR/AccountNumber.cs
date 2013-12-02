using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataOCR
{

    public class AccountNumber
    {
        public const int lineLength = 27;
        public const int numberOfLines = 4;
        
        private static readonly string DefaultLine;
        
        static AccountNumber()
        {
            
            StringBuilder Builder = new StringBuilder();
            
            for (int i = 0; i < lineLength; i++)
                Builder.Append(" ");
            
            DefaultLine = Builder.ToString();
            
            
        }

        public AccountNumber(List<string> Lines)
        {
            ValidateAndRepairConstructorArraySize(Lines);
            ParseLinesIntoEntryNumbers(Lines);
            UpdateID();
        }

        private string id;
        public string ID
        {
            get
            {
                return id;
            }
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
                UpdateID();
            }
        }


        public void ValidateAndRepairConstructorArraySize(List<string> lines)
        {
            if (lines.Count == numberOfLines)
            {
                FixLineLength(lines);  
            }
            else
            {
                FixNumberOfLines(lines);
                FixLineLength(lines);
            }
            
        }

        private void FixLineLength(List<string> lines)
        {
            for (int i = 0; i < numberOfLines; i++)
            {
                if (lines[i].Length > lineLength)
                {
                    StringBuilder SB = new StringBuilder();
                    SB.Append(lines[i].Substring(0, lineLength));
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
        }

        private void FixNumberOfLines(List<string> lines)
        {
            for (int i = lines.Count; i < numberOfLines; i++)
            {
                lines.Add(DefaultLine + "\r\n");
            }
        }

        public void ParseLinesIntoEntryNumbers(List<string> lines)
        {
            string[,] currentEntry = new string[3,3];
            int numberPosition = 0;
            for (int n = 0; n < numbers.Length; n++)
            {
                setCurrentEntryToEntryAtPosition(numberPosition, lines, currentEntry);
                numbers[n] = new EntryNumber(currentEntry);
                numberPosition += 3;
            }
        }

        private void setCurrentEntryToEntryAtPosition(int position, List<string> lines, string[,] currentEntry)
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = position; y < position + 3; y++)
                {
                    currentEntry[x, y % 3] = lines[x].Substring(y, 1);
                }
            }
        }

        private void UpdateID()
        {
            StringBuilder SB = new StringBuilder();

            for (int n = 0; n < numbers.Length; n++)
            {
                SB.Append(numbers[n].ParsedValue.ToString());
            }

            id = SB.ToString();
            
        }

        public bool IsValidAccount()
        {
            int checksum;
            int total = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                total += numbers[i].ParsedValue * (numbers.Length - i);
            }
            checksum = total % 11;
            return checksum == 0 ? true : false;
        }

        public override string ToString()
        {

            StringBuilder SB = new StringBuilder();

            for (int i = 0; i < numbers.Length; i++)
            {
                SB.Append((numbers[i].ParsedValue == -1) ? "?" : Convert.ToString(numbers[i].ParsedValue));
            }

            return SB.ToString();
        }

    }

}
