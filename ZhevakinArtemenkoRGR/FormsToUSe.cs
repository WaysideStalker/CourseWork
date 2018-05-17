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
        public static List<List<string>> ListsList = new List<List<string>>();
        public static int _indexOfCurrent;
        private static string ReadFromSourceFile(string fileName)
        {
            using (StreamReader readFile = new StreamReader($@"DataBase\{fileName}", Encoding.UTF8))
            {
                return readFile.ReadToEnd();
            }
        }
        static FormsToUSe()
        {
            ListsList.Add(new List<string>() { ReadFromSourceFile("FirstTheme.txt"), ReadFromSourceFile("FirstTest.txt"), ReadFromSourceFile("FirstTestAnswers.txt"), ReadFromSourceFile("CorrectAnswers.txt") });
            ListsList.Add(new List<string>() { ReadFromSourceFile("FirstTheme.txt"), ReadFromSourceFile("FirstTest.txt"), ReadFromSourceFile("FirstTestAnswers.txt"), ReadFromSourceFile("CorrectAnswers.txt") });
            ListsList.Add(new List<string>() { ReadFromSourceFile("FirstTheme.txt"), ReadFromSourceFile("FirstTest.txt"), ReadFromSourceFile("FirstTestAnswers.txt"), ReadFromSourceFile("CorrectAnswers.txt") });
        }
    }
}
