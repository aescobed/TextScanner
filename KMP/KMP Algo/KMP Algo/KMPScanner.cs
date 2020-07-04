using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace KMP_Algo
{
    class KMPScanner
    {
        private string FullText;
        private string Pattern;
        private bool CaseSensitive;

        internal KMPScanner(string fullText, string pattern, bool caseSensitive)
        {
            this.FullText = fullText;
            this.Pattern = pattern;
            this.CaseSensitive = caseSensitive;

            int[] testCharTable = FaultTable(this.Pattern);

            for (int i = 0; i < testCharTable.Length; i++)
                Console.Write(testCharTable[i]);


        }

        // Returns the fault table for where to default when mismatch
        internal int[] FaultTable(string pattern)
        {

            int[] res = new int[pattern.Length];

            char[] patChars = pattern.ToCharArray();

            int counter = 0;

            // Find prefixes in pattern
            for(int i = 1; i < patChars.Length; i++)
                if(patChars[i] == patChars[counter])
                {
                    counter++;
                    res[i] = counter;
                }
                else
                {
                    counter = 0;
                }

            return res;
        }

    }
}
