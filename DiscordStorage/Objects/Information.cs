using System.Collections.Generic;
using System.Linq;

namespace DiscordStorage
{
    class Information
    {
        public  List<string> Content { get; set; }

        public Information(params string[] content)
        {
            Content = content.ToList();
        }
    }
}
