using System.Collections.Generic;

namespace DiscordStorage
{
    class UserTools
    {

        internal static bool UserExists(ulong id)
        {
            foreach (var user in Program.userList)
            {
                if (user.ID == id)
                {
                    return true;
                }
            }

            foreach (var group in Program.groupList)
            {
                foreach (var user in group.Users)
                {
                    if (user.ID == id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        internal static void SaveAll()
        {
            foreach (var user in Program.userList)
            {
                string output = "[";

                foreach (var info in user.Info)
                {
                    output += "{";
                    foreach (var text in info.Content)
                    {
                        output += text;
                        output += "|";
                    }
                    output = output.Trim('|');
                }


                FileManipulation.WriteFile(user.ID.ToString(), output);
            }
        }

        internal static void ConcatContent(ulong id, string[] content)
        {
            List<Information> info = GetInformation(id, content[0]);
            content = RemoveFirst(content);
            foreach (var entry in info)
            {

                foreach (var text in content)
                {
                    entry.Content.Add(text);
                }
            }

        }

        internal static string[] RemoveFirst(string[] input)
        {
            string[] holding = new string[input.Length - 1];

            for (int i = 0; i < input.Length; i++)
            {
                string text = input[i];

                if (i != 0)
                {
                    holding[i - 1] = text;
                }
            }

            input = holding;
            return input;
        }

        internal static User GetUser(ulong id)
        {
            if (!UserExists(id))
            {
                Program.userList.Add(new User(id));
            }

            foreach (var user in Program.userList)
            {
                if (user.ID == id)
                {
                    return user;
                }
            }
            return null;
        }

        internal static List<Information> GetInformation(ulong id, string searchTerm)
        {
            User user = GetUser(id);
            List<Information> info = new List<Information>();

            foreach (var entry in user.Info)
            {
                foreach (var text in entry.Content)
                {
                    if (text.Contains(searchTerm))
                    {
                        if (!info.Contains(entry))
                        {
                            info.Add(entry);
                        }
                    }
                }
            }
            return info;
        }

        internal static string GetFirstContent(ulong id, string searchTerm)
        {
            List<Information> info = GetInformation(id, searchTerm);

            foreach (var entry in info)
            {
                foreach (var text in entry.Content)
                {
                    if (text.Contains(searchTerm))
                    {
                        return text;
                    }
                }
            }
            return null;
        }

        internal static string GetAllContent(ulong id)
        {
            string output = "";
            foreach (var info in GetUser(id).Info)
            {
                foreach (var text in info.Content)
                {
                    output += text;
                    output += "\n";
                }
            }
            return output;
        }

        internal static string GetAllContent(ulong id, string searchTerm)
        {
            List<Information> info = GetInformation(id, searchTerm);
            string output = "";

            try
            {
                foreach (var entry in info)
                {

                    foreach (var text in entry.Content)
                    {
                        output += text;
                        output += "|";
                    }
                    output = output.Trim('|');
                    output += "\n";
                }
            }
            catch
            {
                output = "No corresponding entries found.";
            }
            return output;
        }
    }
}
