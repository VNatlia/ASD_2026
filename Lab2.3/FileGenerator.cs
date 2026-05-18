using System.Collections.Generic;
using System.IO;

namespace Lab2._3
{
    public class FileGenerator
    {
        public List<string> Results = new List<string>();

        public void GenerateArrangements(
            int[] participants,
            int k,
            int[] currentTeam,
            bool[] used,
            int position)
        {
            if (position == k)
            {
                string team = "Команда: [";

                for (int i = 0; i < k; i++)
                {
                    team += currentTeam[i];

                    if (i < k - 1)
                    {
                        team += ", ";
                    }
                }

                team += "]";

                Results.Add(team);

                return;
            }

            for (int i = 0; i < participants.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;

                    currentTeam[position] = participants[i];

                    GenerateArrangements(
                        participants,
                        k,
                        currentTeam,
                        used,
                        position + 1);

                    used[i] = false;
                }
            }
        }

        public void SaveToFile(string fileName)
        {
            File.WriteAllLines(fileName, Results);
        }
    }
}