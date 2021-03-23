namespace DiscordStorage
{
    class GroupTools
    {
        internal static void Add(string[] content)
        {
            Group group = FindGroup(content[0]);

            UserTools.RemoveFirst(content);

            group.Info.Add(new Information(content));
        }

        private static Group FindGroup(string id)
        {
            foreach (var group in Program.groupList)
            {
                if (group.ID == id)
                {
                    return group;
                }
            }
            return null;
        }

        internal static void SaveAll()
        {
            foreach (var group in Program.groupList)
            {
                string output = "[";

                foreach (var info in group.Info)
                {
                    output += "{";
                    foreach (var text in info.Content)
                    {
                        output += text;
                        output += "|";
                    }
                    output = output.Trim('|');
                }


                FileManipulation.WriteFile(group.ID.ToString(), output);
            }
        }
    }
}
