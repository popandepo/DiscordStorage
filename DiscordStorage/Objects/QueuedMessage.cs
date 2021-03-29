using Discord;
using System.Collections.Generic;
using System.Timers;

namespace DiscordStorage
{
    class QueuedMessage
    {
        public ulong Sender { get; set; }
        public ulong Reciever { get; set; }
        public List<string> Messages { get; set; }
        public Timer Timer { get; set; }

        public QueuedMessage(ulong sender, ulong reciever, string message, int time = 600)
        {
            Sender = sender;
            Reciever = reciever;
            Messages = new List<string> { message };

            Timer = new Timer(time * 1000);
            Timer.Elapsed += Timer_Elapsed;
            Timer.AutoReset = true;
            Timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var SenderUser = Program._client.GetUser(Sender);
            var RecieverUser = Program._client.GetUser(Reciever);

            if (RecieverUser.Status.ToString() == "Online")
            {
                foreach (var Message in Messages)
                {
                    RecieverUser.SendMessageAsync(
                        $"{SenderUser} enqueued a message:\n" +
                        $"\"{Message}\""
                        );
                    SenderUser.SendMessageAsync(
                        $"The message\n" +
                        $"\"{Message}\"\n" +
                        $"has been sent to {RecieverUser}"
                        );
                }
                Timer.Stop();
                Timer.Dispose();
                Program.queueList.Remove(this);
            }
        }
    }
}
