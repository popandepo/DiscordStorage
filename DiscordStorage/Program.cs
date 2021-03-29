using Discord;
using Discord.WebSocket;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordStorage
{
    class Program
    {

        public static DiscordSocketClient _client;

        public static List<User> userList = new List<User>();
        public static List<Group> groupList = new List<Group>();
        public static List<QueuedMessage> queueList = new List<QueuedMessage>();
        public static List<Reminder> reminderList = new List<Reminder>();

        public static char commandChar = '§';
        public static char splitChar = '|';

        static void Main(string[] args)
        {
            new Program().BotInit().GetAwaiter().GetResult();
        }

        public async Task BotInit() //starts the bot and initiates all handlers
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig() { AlwaysDownloadUsers = true });

            try
            {
                string token = FileManipulation.ReadFile("BotKey.txt");//Reads the token from file
                await _client.LoginAsync(TokenType.Bot, token);
                await _client.StartAsync();
                await _client.SetStatusAsync(UserStatus.Online);
                _client.MessageReceived += MessageHandler.Send;
                while (true)
                {

                }
            }
            catch
            {
                System.Environment.Exit(5);
            }
        }
    }
}
