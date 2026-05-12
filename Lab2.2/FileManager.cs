using System.IO;

namespace Lab2._2
{
    internal class FileManager
    {
        public static string FileName = "text.txt";

        public static void CreateFile()
        {
            if (!File.Exists(FileName))
            {
                File.WriteAllText(FileName,
                    "{123}\n" +
                    "{ABC}\n" +
                    "{A1}\n" +
                    "{HELLO}\n" +
                    "{456}\n" +
                    "!123& !ABC& !A1& !HELLO& !456&");
            }
        }
    }
}