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
        public static List<List<List<string>>> ListsList = new List<List<List<string>>>();
        private static List<List<List<string>>> MackonahellListsList = new List<List<List<string>>>();
        private static List<List<List<string>>> DeytellListsList = new List<List<List<string>>>();
        public static int _indexOfCurrent;
        static FormsToUSe()
        {
            _indexOfCurrent = 0;
            FillForMackonahell();
            FillForDeytel();
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
            DeytellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Deytell\FirstParts.txt"), ReadFromSourceFile(@"Deytell\TestForText.txt") });
            DeytellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Deytell\FirstParts.txt"), ReadFromSourceFile(@"Deytell\FirstParts.txt") });
            DeytellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Deytell\FirstParts.txt"), ReadFromSourceFile(@"Deytell\FirstParts.txt") });
        }

        private static void FillForMackonahell()
        {
            MackonahellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Mackonahell\FirstTheme.txt"), ReadFromSourceFile(@"Deytell\TestForText.txt") });
            MackonahellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Mackonahell\FirstTheme.txt"), ReadFromSourceFile(@"Deytell\TestForText.txt") });
            MackonahellListsList.Add(new List<List<string>>() { ReadFromSourceFile(@"Mackonahell\FirstTheme.txt"), ReadFromSourceFile(@"Deytell\TestForText.txt") });
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
