using System;

namespace Lab2._2
{
    internal class SwitchFSM
    {
        public static bool Check(string word)
        {
            State state = State.Start;

            foreach (char c in word)
            {
                switch (state)
                {
                    case State.Start:

                        if (c == '{')
                            state = State.OpenBrace;
                        else
                            state = State.Error;

                        break;

                    case State.OpenBrace:

                        if (char.IsDigit(c))
                            state = State.Digits;

                        else if (c >= 'A' && c <= 'Z')
                            state = State.Letters;

                        else
                            state = State.Error;

                        break;

                    case State.Digits:

                        if (char.IsDigit(c))
                            state = State.Digits;

                        else if (c == '}')
                            state = State.Final;

                        else
                            state = State.Error;

                        break;

                    case State.Letters:

                        if (c >= 'A' && c <= 'Z')
                            state = State.Letters;

                        else if (c == '}')
                            state = State.Final;

                        else
                            state = State.Error;

                        break;

                    case State.Final:
                        state = State.Error;
                        break;
                }
            }

            return state == State.Final;
        }
    }
}