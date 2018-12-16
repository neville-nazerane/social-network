using SocialNetwork.Core.Defaults;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetwork.Core.Entities
{

    /// <summary>
    /// Aim is to not touch the user entity for common operations
    /// </summary>
    public class DisplayUser : IEntityDefaults
    {

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public int? UserId { get; set; }
        public User User { get; set; }

        [Required]
        public DateTime? CreatedOn { get; set; }

        public DateTime? RespondedOn { get; set; }
    }
}
