using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KataOCR
{

    
    public class EntryParser 
    {
       
        public EntryParser(string filePath)
        {
            List<string> lineList = GatherLinesIntoList(filePath);
            accountList = SplitLinesIntoAccountNumbersList(lineList);
        }

        private List<AccountNumber> accountList;
        public List<AccountNumber> AccountList
        {
            get
            {
                return accountList;
            }
        }

        public string OpenAndReadAndCloseFile(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            string fileContents = file.ReadToEnd();
            
            file.Close();

            return fileContents; 
        }


        public List<string> GatherLinesIntoList(string fileName)
        {
            string fileRawContents = this.OpenAndReadAndCloseFile(fileName);
            List<string> lines = new List<string>();

            for (int i = 0; i < fileRawContents.Length; i += 29)
            {
                string substring = fileRawContents.Substring(i, 29);
                lines.Add(substring);
            }

            return lines;
        }

        public List<AccountNumber> SplitLinesIntoAccountNumbersList(List<string> lines)
        {   
            List<AccountNumber> accounts = new List<AccountNumber>();
            string[] currentEntry = new string[4];

            for (int i = 0; i < lines.Count; i +=4)
            {
                for (int x = 0; x < 4; x++)
                {
                    currentEntry[x] = lines[i + x];
                }
                accounts.Add(new AccountNumber(currentEntry.ToList()));
            }

            return accounts;
        }

        public void PrintResultsToFile(string outputFilePath)
        {
            StringBuilder SB = new StringBuilder();

            foreach (AccountNumber account in accountList)
            {
                SB.Append(account.ToString());
                if (account.ID.Contains("-1"))
                    SB.Append(" ILL\r\n");
                else if (account.IsValidAccount())
                {
                    SB.Append("    \r\n");
                }
                else
                {
                    SB.Append("    \r\n");
                }
            }

            System.IO.File.WriteAllText(@outputFilePath, SB.ToString());
        }
    }
}
