using System;

namespace DiscordStorage
{
    class QueueTools
    {
        internal static void TryCreate(ulong sender, ulong reciever, string message)
        {
            var existing = Exists(sender, reciever);

            if (existing != null)
            {
                existing.Messages.Add(message);
            }
            else
            {
                Program.queueList.Add(new QueuedMessage(sender, reciever, message, 10)); //DEBUG 10 SECONDS, REMOVE "10" WHEN DONE WITH EXPERIMENTS
                Console.WriteLine("DEBUG MESSAGE LINE 17 QueueToold.cs");
            }

        }

        private static QueuedMessage Exists(ulong sender, ulong reciever)
        {
            foreach (var obj in Program.queueList)
            {
                if (obj.Sender == sender && obj.Reciever == reciever)
                {
                    return obj;
                }
            }
            return null;
        }
    }
}
