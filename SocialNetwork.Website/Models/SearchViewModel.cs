using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Website.Models
{
    public class SearchViewModel
    {

        public IEnumerable<DisplayUser> Results { get; set; }

        public DisplayUserSearch Search { get; set; }

    }
}
