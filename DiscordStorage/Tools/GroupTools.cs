using System.Collections.Generic;

namespace DiscordStorage
{
    class GroupTools
    {
        internal static void Add(string[] content)
        {
            Group group = GetGroup(content[0]);

            content = UserTools.RemoveFirst(content);

            group.Info.Add(new Information(content));
        }

        private static Group GetGroup(string id)
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

        internal static List<Information> GetInformation(string id, string searchTerm)
        {
            Group group = GetGroup(id);
            List<Information> info = new List<Information>();

            foreach (var entry in group.Info)
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

        internal static string GetAllContent(string[] input)
        {
            List<Information> info = GetInformation(input[0], input[1]);
            string output = "";

            try
            {
                foreach (var entry in info)
                {

                    for (int i = 0; i < entry.Content.Count; i++)
                    {
                        string text = entry.Content[i];
                        output += text;
                        if (i == 0)
                        {
                            output += ": ";
                        }
                        else
                        {
                            output += ", ";
                        }
                    }
                    output = output.Trim(' ');
                    output = output.Trim(',');
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
