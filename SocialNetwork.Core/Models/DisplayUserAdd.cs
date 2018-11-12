using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetwork.Core.Models
{
    public class DisplayUserAdd
    {

        [Required, MaxLength(60)]
        public string DisplayName { get; set; }

        [Required]
        public int? UserId { get; set; }

    }
}
