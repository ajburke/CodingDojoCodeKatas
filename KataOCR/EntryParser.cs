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

        public string OpenAndReadFile(string fileName)
        {
            StreamReader file = new StreamReader(fileName);
            string fileContents = file.ReadToEnd();
            
            file.Close();

            return fileContents; 
        }


        public List<string> GatherEntriesIntoList(string fileName)
        {
            string fileRawContents = this.OpenAndReadFile(fileName);
            List<string> entries = new List<string>();

            //string fileContentsWithNoReturns = fileRawContents.Replace("\r\n", "");

            for (int i = 0; i < fileRawContents.Length; i += 116)
            {
                string substring = fileRawContents.Substring(i, 116);
             entries.Add(substring);
            }

            return entries;
        }

    }
}
