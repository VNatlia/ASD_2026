using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab2._2
{
    internal class RegexChecker
    {
        public static void CheckFile()
        {
            string regex = @"^\{(\d+|[A-Z]+)\}$";

            string[] lines = File.ReadAllLines(FileManager.FileName);

            foreach (string line in lines)
            {
                if (Regex.IsMatch(line, regex))
                {
                    Console.WriteLine("Знайдено: " + line);
                }
            }
        }
    }
}