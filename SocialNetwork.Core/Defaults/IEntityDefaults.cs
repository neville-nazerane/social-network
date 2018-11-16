using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Core.Defaults
{
    public interface IEntityDefaults
    {

        int Id { get; set; }

        DateTime? CreatedOn { get; set; }

        DateTime? UpdatedOn { get; set; }

    }
}
