using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Website.Models
{
    public class UserViewModel
    {

        public DisplayUser User { get; set; }

        public FriendStatus FriendStatus { get; set; }

    }
}
