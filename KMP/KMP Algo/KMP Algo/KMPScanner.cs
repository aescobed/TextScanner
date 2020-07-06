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
        private int[] FaultTable;

        internal KMPScanner(string fullText, string pattern, bool caseSensitive)
        {
            this.FullText = fullText;
            this.Pattern = pattern;
            this.CaseSensitive = caseSensitive;

            this.FaultTable = GetFaultTable();

            /*

            for (int i = 0; i < FaultTable.Length; i++)
                Console.Write(FaultTable[i]);
            Console.Write("\n");

            */

            FindString();

        }

        // Returns the fault table for where to default when mismatch
        internal int[] GetFaultTable()
        {

            int[] res = new int[this.Pattern.Length];

            char[] patChars = this.Pattern.ToCharArray();

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


        // Returns the indexes of which the pattern is found in the full text
        internal int[] FindString()
        {

            int j = -1;

            char[] patChars = this.Pattern.ToCharArray();

            for (int i = 0; i < FullText.Length; i++)
            {
                
                if (patChars[j + 1] == FullText[i])
                {
                    j++;
                    if(j == patChars.Length - 1)
                    {
                        Console.Write("Found pattern at index {0} \n", i - patChars.Length);
                    }
                }
                else if(j > -1)
                {
                    
                    j = FaultTable[j] - 1;
                    i--;
                }
                    

            }



            return null;

        }



    }
}
