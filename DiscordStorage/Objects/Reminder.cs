using Discord;
using System.Timers;

namespace DiscordStorage
{
    class Reminder
    {
        public ulong ID { get; set; }
        public string Message { get; set; }
        public string Game { get; set; }
        public Timer Timer { get; set; }
        public Reminder(ulong id, string message, string game)
        {
            ID = id;
            Message = message;
            Game = game.ToLower();

            Timer = new Timer(30_000);
            Timer.Elapsed += Timer_Elapsed;
            Timer.AutoReset = true;
            Timer.Start();

        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
         var User = Program._client.GetUser(ID);
            try
            {
                if (User.Activity.Name.ToLower().Contains(Game))
                {
                    User.SendMessageAsync($"You wanted to be reminded about: \n" +
                        $"{Message}.\n" +
                        $"When you were playing {User.Activity}");
                    Timer.Stop();
                    Timer.Dispose();
                    Program.reminderList.Remove(this);
                }
            }
            catch { }
        }
    }
}
