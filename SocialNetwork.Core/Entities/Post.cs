using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocialNetwork.Core.Entities
{
    public class Post
    {

        public int Id { get; set; }

        [Required, MaxLength(300)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required]
        public int? CreatedById { get; set; }
        [ForeignKey(nameof(CreatedById))]
        public DisplayUser CreatedBy { get; set; }

        [Required]
        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
}
