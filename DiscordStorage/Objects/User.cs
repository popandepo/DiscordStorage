using System.Collections.Generic;

namespace DiscordStorage
{
    class User
    {
        public ulong ID { get; set; }
        public List<Information> Info { get; set; }

        public User(ulong id)
        {
            ID = id;
            Info = new List<Information>();
        }
    }
}
