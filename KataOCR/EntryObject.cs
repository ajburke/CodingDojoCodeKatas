using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataOCR
{
    class EntryObject
    {
        private int[] accountNumber = new int[9];
        public int[] AccountNumber
        {
            get
            {
                return accountNumber;
            }
            set
            {
                accountNumber = value;
            }
        }

    }
}
