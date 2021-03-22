using System.Collections.Generic;
using System.Linq;

namespace DiscordStorage
{
    class Group
    {
        ulong ID { get; set; }
        List<User> Users { get; set; }
        List<Information> Info { get; set; }

        public Group(ulong id, params User[] users)
        {
            ID = id;
            Users = users.ToList();
        }
    }
}
