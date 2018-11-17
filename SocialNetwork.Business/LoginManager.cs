using Microsoft.AspNetCore.Identity;
using NetCore.ModelValidation.Core;
using SocialNetwork.Core.Entities;
using SocialNetwork.Core.Models;
using SocialNetwork.Services;
using SocialNetwork.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Business
{
    class LoginManager : ILoginManager
    {
        private readonly SignInManager<User> signInManager;
        private readonly IDisplayUserRepository displayUserRepository;
        private readonly ModelValidator modelValidator;
        private readonly ILoginContext loginContext;

        public LoginManager(
                                SignInManager<User> signInManager,
                                IDisplayUserRepository displayUserRepository,
                                ModelValidator modelValidator,
                                ILoginContext loginContext
                            )
        {
            this.signInManager = signInManager;
            this.displayUserRepository = displayUserRepository;
            this.modelValidator = modelValidator;
            this.loginContext = loginContext;
        }

        UserManager<User> UserManager => signInManager.UserManager;

        public async Task<bool> LoginAsync(Login login)
        {
            var result = await signInManager.PasswordSignInAsync(login.UserName, login.Password, true, false);
            if (result.Succeeded)
            {
                var user = UserManager.Users.SingleOrDefault(u => u.UserName == login.UserName);
                loginContext.RegisterLogin(user);
                return true;
            }
            else if (result.IsLockedOut) modelValidator.AddError("Account has been locked out");
            else if (result.IsNotAllowed) modelValidator.AddError("Invalid login");
            else modelValidator.AddError("Login failed");
            return false;
        }

        public async Task<bool> SignUp(SignUp signUp)
        {
            var user = new User
            {
                UserName = signUp.UserName,
                Email = signUp.Email
            };
            var result = await UserManager.CreateAsync(user, signUp.Password);
            if (result.Succeeded)
            {
                displayUserRepository.Add(signUp);
                return true;
            }
            else
            {
                foreach (string err in result.Errors.Select(e => e.Description))
                    modelValidator.AddError(err);
                return false;
            }
        }

    }
}
