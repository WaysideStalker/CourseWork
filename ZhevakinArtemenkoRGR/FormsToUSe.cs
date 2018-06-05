using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace ZhevakinArtemenkoRGR
{
    public static class FormsToUSe
    {
        public static List<string> TypicalMistakesDeitel = new List<string>();
        public static List<List<List<string>>> ListsList = new List<List<List<string>>>();
        public static List<List<List<string>>> MackonahellListsList = new List<List<List<string>>>();
        private static List<List<List<string>>> DeytellListsList = new List<List<List<string>>>();
        public static int _indexOfCurrent;
        public static int _TypicalMistakesIndex;
        static FormsToUSe()
        {
            _indexOfCurrent = 0;
            FillForMackonahell();
            FillForDeytel();
        }

        private static string ReadTypicalMistakesDeitel(string filename)
        {
            using (StreamReader readfile = new StreamReader($@"DataBase\{filename}"))
            {
                return readfile.ReadToEnd();
            }
        }
        private static List<string> ReadFromSourceFile(string fileName)
        {
            List<string> themeAndGoodBadStyles = new List<string>();
            using (StreamReader readFile = new StreamReader($@"DataBase\{fileName}", Encoding.ASCII))
            {
                bool endOfTextFile = false;
                for (int i = 0; !endOfTextFile; i++)
                {
                    themeAndGoodBadStyles.Add(null);
                    while (true)
                    {
                        var readline = readFile.ReadLine();
                        if (readline == "^") break;
                        if (readline == "FileEnd")
                        {
                            endOfTextFile = true;
                            break;
                        }
                        themeAndGoodBadStyles[i] += readline + "\n";
                    }
                }
            }

            return themeAndGoodBadStyles;
        }

        private static void FillForDeytel()
        {
            DeytellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Deytell\FirstPart.txt"), ReadFromSourceFile(@"Deytell\FirstTest.txt") });
            DeytellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Deytell\SecondPart.txt"), ReadFromSourceFile(@"Deytell\SecondTest.txt") });
            DeytellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Deytell\ThirdPart.txt"), ReadFromSourceFile(@"Deytell\ThirdTest.txt") });
            DeytellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Deytell\FourthPart.txt"), ReadFromSourceFile(@"Deytell\FourthTest.txt") });
            DeytellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Deytell\FifthPart.txt"), ReadFromSourceFile(@"Deytell\FifthTest.txt") });
        }

        public static void FillMistakesForDeitel()
        {
            TypicalMistakesDeitel.Add(ReadTypicalMistakesDeitel((@"Deytell\FirstTest.txt")));
        }

        private static void FillForMackonahell()
        {
            MackonahellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Mackonahell\FirstTheme.txt"), ReadFromSourceFile(@"Deytell\FirstTest.txt") });
            MackonahellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Mackonahell\SecondTheme.txt"), ReadFromSourceFile(@"Deytell\ThirdTest.txt") });
            MackonahellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Mackonahell\ThirdTheme.txt"), ReadFromSourceFile(@"Deytell\ThirdTest.txt") });
            MackonahellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Mackonahell\FourthTheme.txt"), ReadFromSourceFile(@"Deytell\FourthTest.txt") });
            MackonahellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Mackonahell\FifthTheme.txt"), ReadFromSourceFile(@"Deytell\SecondTest.txt") });
            MackonahellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Mackonahell\SixthTheme.txt"), ReadFromSourceFile(@"Deytell\FifthTest.txt") });

        }

        public static void UseDaytell()
        {
            ListsList = DeytellListsList;
        }
        public static void UseMackonahell()
        {
            ListsList = MackonahellListsList;
        }
    }
}
