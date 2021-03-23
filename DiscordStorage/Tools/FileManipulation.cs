using System;
using System.IO;

namespace DiscordStorage
{
    public class FileManipulation
    {

        /// <summary>
        /// Reads a file with the given filename
        /// </summary>
        /// <param name="fileName">The name of the file to read</param>
        /// <returns>A string with the contents of the file</returns>
        public static string ReadFile(string fileName)
        {
            var filePath = Path.GetFullPath(fileName);

            string output = File.ReadAllText(filePath);

            return output;
        }

        internal static void LoadFile(string id)
        {
            string input = File.ReadAllText(id);

            string[] sqbr = input.Split('[');
            sqbr = UserTools.RemoveFirst(sqbr);

            string[] crbr = sqbr[0].Split('{');
            crbr = UserTools.RemoveFirst(crbr);

            foreach (var text in crbr)
            {
                string[] words = text.Split('|');
                User user = UserTools.GetUser(Convert.ToUInt64(id));

                user.Info.Add(new Information(words));
            }
        }

        internal static void WriteFile(string name, string output)
        {
            File.WriteAllText(name, output);
        }
    }
}