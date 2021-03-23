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
                case "?":
                    Program._client.GetUser(id).SendMessageAsync(UserTools.GetAllContent(id, content[0]));
                    break;
                default:
                    break;
            }


            return;
        }
    }
}
