using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ZhevakinArtemenkoRGR
{
    public static class FormsToUSe
    {
        public static List<List<string[]>> ListsList = new List<List<string[]>>();
        public static int _indexOfCurrent;
        private static string[] ReadFromSourceFile(string fileName)
        {
            string[] themeAndGoodBadStyles = new string[10];
            using (StreamReader readFile = new StreamReader($@"DataBase\{fileName}", Encoding.UTF8))
            {
                for (int i = 0; i < 10; i++)
                {
                    while (true)
                    {
                        if (readFile.ReadLine() == "^\n")
                            break;
                        themeAndGoodBadStyles[i] += readFile.ReadLine();
                    }
                }
            }

            return themeAndGoodBadStyles;
        }
        static FormsToUSe()
        {
            ListsList.Add(new List<string[]>() { ReadFromSourceFile("FirstTheme.txt"), ReadFromSourceFile("FirstTest.txt") });
            ListsList.Add(new List<string[]>() { ReadFromSourceFile("FirstTheme.txt"), ReadFromSourceFile("FirstTest.txt") });
            ListsList.Add(new List<string[]>() { ReadFromSourceFile("FirstTheme.txt"), ReadFromSourceFile("FirstTest.txt") });

        }
    }
}
