using System.Collections.Generic;
using System.Linq;

namespace DiscordStorage
{
    class Group
    {
        public ulong ID { get; set; }
        public List<User> Users { get; set; }
        public List<Information> Info { get; set; }

        public Group(ulong id, params User[] users)
        {
            ID = id;
            Users = users.ToList();
        }
    }
}
