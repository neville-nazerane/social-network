using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetwork.Core.Models
{
    public class PostUpdate
    {

        public int Id { get; set; }

        [Required, MaxLength(300)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

    }
}
