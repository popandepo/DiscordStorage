using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
