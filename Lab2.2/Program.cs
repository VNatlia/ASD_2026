using System;
using System.IO;
using Lab2._2;

namespace Lab2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileManager.CreateFile();

            Console.WriteLine("РІВЕНЬ 1. Пошук за регулярним виразом");
            RegexChecker.CheckFile();

            Console.WriteLine("\nРІВЕНЬ 2. Перевірка через switch");

            Console.Write("Введіть слово: ");
            string word = Console.ReadLine();

            bool result = SwitchFSM.Check(word);

            Console.WriteLine(result
                ? "Слово правильне"
                : "Слово неправильне");

            Console.WriteLine("\nРІВЕНЬ 3. Перевірка через таблицю переходів");

            TableFSM.CheckWordsFromFile();
        }
    }
}