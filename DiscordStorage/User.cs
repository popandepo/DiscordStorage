using System.Collections.Generic;

namespace DiscordStorage
{
    class User
    {
        ulong ID { get; set; }
        List<Information> Info { get; set; }

        public User(ulong id)
        {
            ID = id;
            Info = new List<Information>();
        }
    }
}
