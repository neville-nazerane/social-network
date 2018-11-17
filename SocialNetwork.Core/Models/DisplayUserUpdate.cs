using SocialNetwork.Core.Defaults;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetwork.Core.Models
{
    public class DisplayUserUpdate : IUpdateDefaults
    {

        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }
    }
}
