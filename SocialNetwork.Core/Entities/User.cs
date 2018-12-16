using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Core.Entities
{
    public class User : IdentityUser<int>
    {

        public DisplayUser DisplayUser { get; set; }

        public static implicit operator User(User v)
        {
            throw new NotImplementedException();
        }
    }
}
