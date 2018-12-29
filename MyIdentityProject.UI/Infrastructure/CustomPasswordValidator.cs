using Microsoft.AspNetCore.Identity;
using MyIdentityProject.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyIdentityProject.UI.Infrastructure
{
    public class CustomPasswordValidator : IPasswordValidator<ApplicationUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password)
        {
            var _password = password.ToLower();
            var _userName = user.UserName.ToLower();
            List<IdentityError> errors = new List<IdentityError>();
            if (_password.Contains(_userName))
            {
               errors.Add(new IdentityError()
                {
                    Code = "PassUNameContains",
                    Description="Password value can not contains the User Name Value"
                });
            }

            if (_password.Contains("123"))
            {
                errors.Add(new IdentityError()
                {
                    Code = "PassContainsSeq",
                    Description = "Password value can not contains numeric sequence"
                });
            }

            return Task.FromResult(errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
