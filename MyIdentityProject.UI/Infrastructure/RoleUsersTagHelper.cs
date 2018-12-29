using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MyIdentityProject.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyIdentityProject.UI.Infrastructure
{
    [HtmlTargetElement("td",Attributes ="IdentityRole")]
    public class RoleUsersTagHelper:TagHelper
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        [HtmlAttributeName("IdentityRole")]
        public string RoleId { get; set; }

        public RoleUsersTagHelper(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> roleNames = new List<string>();
            var role = await roleManager.FindByIdAsync(RoleId);
            if (role!=null)
            {
                foreach (var user in userManager.Users)
                {
                    var isInRole = await userManager.IsInRoleAsync(user, role.Name);
                    if (isInRole)
                    {
                        roleNames.Add(user.UserName);
                    }
                }
            }

            output.Content.SetContent(roleNames.Count == 0 ? "No Users" : string.Join(", ", roleNames));
        }
    }
}
