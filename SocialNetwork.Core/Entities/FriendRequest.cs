using SocialNetwork.Core.Defaults;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SocialNetwork.Core.Entities
{
    public class FriendRequest : IEntityDefaults
    {

        public int Id { get; set; }

        [Required]
        public int? RequesterId { get; set; }
        public DisplayUser Requester { get; set; }

        [Required]
        public int? RequestedForId { get; set; }
        public DisplayUser RequestedFor { get; set; }

        public bool? IsApproved { get; set; }

        [Required]
        public DateTime? CreatedOn { get; set; }

        public DateTime? RespondedOn { get; set; }

    }
}
