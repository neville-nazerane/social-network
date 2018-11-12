using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetwork.Core.Entities
{

    /// <summary>
    /// Aim is to not touch the user entity for common operations
    /// </summary>
    public class DisplayUser
    {

        public int Id { get; set; }

        [Required, MaxLength(60)]
        public string DisplayName { get; set; }

        [Required]
        public int? UserId { get; set; }
        public User User { get; set; }

    }
}
