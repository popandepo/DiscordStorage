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

        internal static void ConcatContent(ulong id, string[] content)
        {
            Information info = GetInformation(id, content[0]);
            string[] holding = new string[content.Length - 1];

            for (int i = 0; i < content.Length; i++)
            {
                string text = content[i];

                if (i != 0)
                {
                    holding[i - 1] = text;
                }
            }

            content = holding;

            foreach (var text in content)
            {
                info.Content.Add(text);
            }

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

        internal static Information GetInformation(ulong id, string searchTerm)
        {
            User user = GetUser(id);

            foreach (var entry in user.Info)
            {
                foreach (var text in entry.Content)
                {
                    if (text.Contains(searchTerm))
                    {
                        return entry;
                    }
                }
            }
            return null;
        }

        internal static string GetFirstContent(ulong id, string searchTerm)
        {
            Information info = GetInformation(id, searchTerm);

            foreach (var text in info.Content)
            {
                if (text.Contains(searchTerm))
                {
                    return text;
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
            Information info = GetInformation(id, searchTerm);
            string output = "";

            try
            {
                foreach (var text in info.Content)
                {
                    output += text;
                    output += "|";
                }
                output = output.Trim('|');
            }
            catch
            {
                output = "No corresponding entries found.";
            }
            return output;
        }
    }
}
