using SocialNetwork.Core.Defaults;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetwork.Core.Entities
{
    public class Friend : IEntityDefaults
    {

        public int Id { get; set; }

        [Required]
        public int? User1Id { get; set; }
        public DisplayUser User1 { get; set; }

        [Required]
        public int? User2Id { get; set; }
        public DisplayUser User2 { get; set; }

        [Required]
        public DateTime? CreatedOn { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }
}
