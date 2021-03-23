using Discord;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace DiscordStorage
{
    class MessageHandler
    {
        internal static Task Send(SocketMessage message)
        {
            if (!message.Author.IsBot)
            {
                if (message.Content.Contains(Program.commandChar))
                {


                    try
                    {
                        string command = message.Content.Split(Program.commandChar)[0];
                        string rest = message.Content.Remove(0, command.Length + 1);
                        string[] content = rest.Split(Program.splitChar);

                        CommandHandler.Send(message.Author.Id, command, content);
                    }
                    catch
                    {
                        message.Author.SendMessageAsync("Command is not correctly formatted, please try again or contact an administrator");
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
