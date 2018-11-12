using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetwork.Core.Entities
{
    public class Friend
    {

        [Required]
        public int? User1Id { get; set; }
        public DisplayUser User1 { get; set; }

        [Required]
        public int? User2Id { get; set; }
        public DisplayUser User2 { get; set; }

    }
}
