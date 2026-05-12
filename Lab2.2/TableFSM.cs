using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab2._2
{
    internal class TableFSM
    {
        public static void CheckWordsFromFile()
        {
            string text = File.ReadAllText(FileManager.FileName);

            MatchCollection matches =
                Regex.Matches(text, @"!(.*?)&");

            foreach (Match match in matches)
            {
                string word = match.Groups[1].Value;

                string fullWord = "{" + word + "}";

                bool result = Check(fullWord);

                Console.WriteLine(word + " -> " +
                    (result ? "ПРАВИЛЬНЕ" : "НЕПРАВИЛЬНЕ"));
            }
        }

        public static bool Check(string word)
        {
            State[,] table =
            {
                { State.OpenBrace, State.Error,  State.Error,   State.Error, State.Error },
                { State.Error,     State.Digits, State.Letters, State.Error, State.Error },
                { State.Error,     State.Digits, State.Error,   State.Final, State.Error },
                { State.Error,     State.Error,  State.Letters, State.Final, State.Error },
                { State.Error,     State.Error,  State.Error,   State.Error, State.Error },
                { State.Error,     State.Error,  State.Error,   State.Error, State.Error }
            };

            State state = State.Start;

            for (int i = 0; i < word.Length; i++)
            {
                int column = GetColumn(word[i]);

                state = table[(int)state, column];
            }

            return state == State.Final;
        }

        static int GetColumn(char c)
        {
            if (c == '{') return 0;

            if (char.IsDigit(c)) return 1;

            if (c >= 'A' && c <= 'Z') return 2;

            if (c == '}') return 3;

            return 4;
        }
    }
}