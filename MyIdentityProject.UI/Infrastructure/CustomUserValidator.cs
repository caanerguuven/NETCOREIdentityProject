using Microsoft.AspNetCore.Identity;
using MyIdentityProject.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyIdentityProject.UI.Infrastructure
{
    public class CustomUserValidator : IUserValidator<ApplicationUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user)
        {
            var _email = user.Email.ToLower();
            if (_email.EndsWith("@hotmail.com") || _email.EndsWith("@gmail.com"))
            {
                return Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError()
                {
                    Code = "JustHotmailAndGmail",
                    Description = "It can be let just hotmail and gmail accounts"
                }));
            }
        }
    }
}
