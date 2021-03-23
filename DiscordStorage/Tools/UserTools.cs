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

        internal static string GetAllContent(ulong id, string searchTerm)
        {
            Information info = GetInformation(id, searchTerm);
            string output = "";
            foreach (var text in info.Content)
            {
                if (text.Contains(searchTerm))
                {
                    output += text;
                    output += "\n";
                }
            }
            return output;
        }
    }
}
