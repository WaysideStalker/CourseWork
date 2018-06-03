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
                bool endOfTextFile = false;
                for (int i = 0;!endOfTextFile; i++)
                {
                    while (true)
                    {
                        var readline = readFile.ReadLine();
                        if (readline == "^")break;
                        if (readline == "FileEnd") endOfTextFile = true;
                        themeAndGoodBadStyles[i] += readline +"\n";
                    }
                }
            }

            return themeAndGoodBadStyles;
        }
        static FormsToUSe()
        {
            _indexOfCurrent = 0;
            ListsList.Add(new List<string[]>() { ReadFromSourceFile("FirstParts.txt"), ReadFromSourceFile("FirstParts.txt") });
            ListsList.Add(new List<string[]>() { ReadFromSourceFile("FirstParts.txt"), ReadFromSourceFile("FirstParts.txt") });
            ListsList.Add(new List<string[]>() { ReadFromSourceFile("FirstParts.txt"), ReadFromSourceFile("FirstParts.txt") });

        }
    }
}
