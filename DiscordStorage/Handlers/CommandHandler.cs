using Discord;

namespace DiscordStorage
{
    class CommandHandler
    {
        internal static void Send(ulong id, string command, string[] content)
        {
            User user = UserTools.GetUser(id);
            switch (command)
            {
                case "+":
                    user.Info.Add(new Information(content));
                    break;
                case "++":
                    UserTools.ConcatContent(id, content);
                    break;
                case "?":
                    Program._client.GetUser(id).SendMessageAsync(UserTools.GetAllContent(id, content[0]));
                    break;
                case "??":
                    Program._client.GetUser(id).SendMessageAsync(UserTools.GetAllContent(id));
                    break;
                default:
                    break;
            }


            return;
        }
    }
}
