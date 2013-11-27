using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KataOCR
{

    
    public class EntryParser 
    {

        public List<AccountNumber> AccountList { get; private set; }

        public EntryParser(string filePath)
        {
            List<string> lineList = File.ReadAllLines(filePath).ToList();
            AccountList = SplitLinesIntoAccountNumbersList(lineList);
        }

        public List<AccountNumber> SplitLinesIntoAccountNumbersList(List<string> lines)
        {   
            List<AccountNumber> accounts = new List<AccountNumber>();
            List<string> currentEntry = new List<string>();

            for (int i = 0; i < lines.Count; i +=4)
            {

                currentEntry.Clear();

                for (int x = 0; x < 4; x++)
                {
                    currentEntry.Add(lines[i + x]);
                }

                accounts.Add(new AccountNumber(currentEntry));

            }

            return accounts;
        }

        public void PrintResultsToFile(string outputFilePath)
        {
            StringBuilder SB = new StringBuilder();

            foreach (AccountNumber account in AccountList)
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
