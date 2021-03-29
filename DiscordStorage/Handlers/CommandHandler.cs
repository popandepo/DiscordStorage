using Discord;
using System;

namespace DiscordStorage
{
    class CommandHandler
    {
        internal static void Send(ulong id, string command, string[] content)
        {
            /*commands to copypaste
            * § = command character
            * | = break character
            * 
            * + = add entry to personal list
            * ++ add to the end of an existing entry
            * ? search for keyword
            * ?? display all of your information
            * 
            * &+ create a group
            * 
            * G+ add entry to group list
            * G? search for entry in group list
            * 
            * examples:
            * +§shopping list|5 apples|6 lentils|bucket of milk|metric ton of meat
            * 
            * ?§shopping list
            * ?§shopping
            * 
            * G+§235921495236940355|daniel|charmeleon
            * G+§235921495236940355|marius|blastoise
            * 
            * G?§235921495236940355|caterpie
            */


            User user = UserTools.GetUser(id);
            switch (command)
            {
                case "queue":
                    QueueTools.TryCreate(id, Convert.ToUInt64(content[0]), content[1]);
                    break;
                case "remind":
                    ReminderTools.TryCreate(id, content[0], content[1]);
                    break;
                case "+":
                    UserTools.Add(id, content);
                    UserTools.SaveAll();
                    break;
                case "++":
                    UserTools.ConcatContent(id, content);
                    UserTools.SaveAll();
                    break;
                case "?":
                    Program._client.GetUser(id).SendMessageAsync(UserTools.GetAllContent(id, content[0]));
                    break;
                case "??":
                    Program._client.GetUser(id).SendMessageAsync(UserTools.GetAllContent(id));
                    break;

                case "&+":
                    GroupTools.CreateGroup(id, content);
                    break;
                case "G+":
                    GroupTools.Add(content);
                    GroupTools.SaveAll();
                    break;
                case "G?":
                    Program._client.GetUser(id).SendMessageAsync(GroupTools.GetAllContent(content));
                    break;
                default:
                    break;
            }


            return;
        }
    }
}
