using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordStorage
{
    class Group
    {
        ulong ID { get; set; }
        List<User> Users { get; set; }
        List<Information> Info { get; set; }
    }
}
