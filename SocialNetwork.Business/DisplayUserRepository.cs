using System;
using System.Collections.Generic;
using System.Text;
using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using SocialNetwork.Services;
using SocialNetwork.Services.DataAccess;
using SocialNetwork.Services.Repositories;

namespace SocialNetwork.Business
{
    class DisplayUserRepository : IDisplayUserRepository
    {
        private readonly IDisplayUserAccess access;
        private readonly ILoginContext loginContext;

        public DisplayUserRepository(IDisplayUserAccess access, ILoginContext loginContext)
        {
            this.access = access;
            this.loginContext = loginContext;
        }

        public DisplayUser Update(DisplayUserUpdate displayUser) 
            => access.Update(displayUser, loginContext.UserId);
        
        public DisplayUser GetCurrent() => access.GetByUserId(loginContext.UserId);

        public IEnumerable<DisplayUser> Search(DisplayUserSearch search) => access.Search(search);

        public IEnumerable<DisplayUser> Get() => access.Get();
        
    }
}
