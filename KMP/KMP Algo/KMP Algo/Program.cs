using System;

namespace KMP_Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            String text = "search this string of strings";
            String pattern1 = "string";
            String pattern2 = "repeated";
            String pattern3 = "aaabbaacdaaabbaac";

            KMPScanner scanner = new KMPScanner(text, pattern3, false);
        }
    }



}
