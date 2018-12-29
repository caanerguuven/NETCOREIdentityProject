using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyIdentityProject.UI.Models
{
    public class RoleModel
    {
        public class RoleDetails {
            public IdentityRole Role { get; set; }
            public IEnumerable<ApplicationUser> RoleMembers { get; set; }
            public IEnumerable<ApplicationUser> NonRoleMembers { get; set; }
        }

        public class RoleEditModel {
            public string RoleId { get; set; }
            public string RoleName { get; set; }
            public string[] UserIdsToAdd { get; set; }
            public string[] UserIdsToDelete { get; set; }
        }
    }
}
