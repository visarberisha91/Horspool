﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Horspool
{
    class Program
    {
        static int NO_OF_CHARS = 256;


        static int max(int a, int b) { return (a > b) ? a : b; }
        static void badCharHeuristic(char[] str, int size, int[] badchar)
        {
            int i;

            // Initialize all occurrences as -1  
            for (i = 0; i < NO_OF_CHARS; i++)
                badchar[i] = -1;
            for (i = 0; i < size; i++)
                badchar[(int)str[i]] = i;
        }
        public static void Search(char[] txt, char[] pat)
        {
            int m = pat.Length;
            int n = txt.Length;

            int[] badchar = new int[NO_OF_CHARS];
            badCharHeuristic(pat, m, badchar);

            int s = 0;
            while (s <= (n - m))
            {
                int j = m - 1;
                while (j >= 0 && pat[j] == txt[s + j])
                    j--;
                if (j < 0)
                {
                    Console.WriteLine("paterni u gjet ne  = " + s);
                    s += (s + m < n) ? m - badchar[txt[s + m]] : 1;

                }

                else

                    s += max(1, j - badchar[txt[s + j]]);
            }
        }


        public static void Main(string[] args)
        {
            Console.WriteLine("Ju lutem jepeni tekstin qe deshironi te kerkoni");
            char[] texti = Console.ReadLine().ToCharArray();
            Console.WriteLine("Ju lutem jepeni paternin");
            char[] patt = Console.ReadLine().ToCharArray();

            //  char[] txt = "ABAAABCD".ToCharArray();
            //  char[] pat = "ABC".ToCharArray();
            Search(texti, patt);
            Console.ReadLine();
        }

    }
}
