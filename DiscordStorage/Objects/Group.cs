using Discord;
using System.Collections.Generic;
using System.Linq;

namespace DiscordStorage
{
    class Group
    {
        public string ID { get; set; }
        public List<User> Users { get; set; }
        public List<Information> Info { get; set; }

        public Group(params User[] users)
        {
            Users = users.ToList();
            ID = "";
            foreach (var user in Users)
            {
                ID += user.ID;
            }
            foreach (var user in Users)
            {
                string output = "You have been added to a group with the members: ";
                foreach (var User in Users)
                {
                    output += $"{Program._client.GetUser(User.ID).Username}, ";
                }
                output = output.Trim(' ');
                output = output.Trim(',');
                output += ".\n";

                output += $"To access the group, use the ID: {ID} after the \"§\"";

                Program._client.GetUser(user.ID).SendMessageAsync(output);
            }
        }
    }
}
