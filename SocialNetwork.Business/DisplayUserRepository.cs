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

        public DisplayUser Add(SignUp displayUser) => access.Add(displayUser);

        public DisplayUser Update(DisplayUserUpdate displayUser) 
            => access.Update(displayUser, loginContext.UserId);

        public bool Delete(int id) => access.Delete(id);

        public bool Exists(int id) => access.Exists(id);

        public DisplayUser Get(int id) => access.Get(id);

        public IEnumerable<DisplayUser> Get() => access.Get();

        public DisplayUser GetCurrent() => Get(loginContext.UserId);
    }
}
