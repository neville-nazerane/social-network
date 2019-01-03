using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialNetwork.Core.Entities
{
    public class User : IdentityUser<int>
    {
        
        public DisplayUser DisplayUser { get; set; }

    }
}
