using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KataOCR
{

    
    public class EntryParser 
    {
       
        public EntryParser()
        {
          
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
        /*
        public List<AccountNumber> SplitLinesIntoAccountNumbersList(List<string> lines)
        {
            
        }
       */
    }
}
