using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.Business.Extensions
{
    public class BusinessServiceOptions
    {

        public IdentityBuilder IdentityBuilder { get; internal set; }

        internal BusinessServiceOptions()
        {

        }

    }
}
