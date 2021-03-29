using System;

namespace DiscordStorage
{
    class ReminderTools
    {
        internal static void TryCreate(ulong id, string message, string game)
        {
            Program.reminderList.Add(new Reminder(id, message, game));
        }
    }
}
