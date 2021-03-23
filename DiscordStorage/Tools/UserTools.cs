using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordStorage
{
    class UserTools
    {
        internal static bool UserExists(ulong id)
        {
            foreach (var user in Program.userList)
            {
                if (user.ID == id)
                {
                    return true;
                }
            }

            foreach (var group in Program.groupList)
            {
                foreach (var user in group.Users)
                {
                    if (user.ID == id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
