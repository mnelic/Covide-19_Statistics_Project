using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidApp_Part2.Infrastructure
{
    [HtmlTargetElement("td", Attributes = "identity-user")]
    public class UserRoleTagHelper : TagHelper
    {
        private UserManager<IdentityUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserRoleTagHelper(UserManager<IdentityUser> userManager,
                                 RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HtmlAttributeName("identity-user")]
        public string User { get; set; }
        public override async Task ProcessAsync(TagHelperContext context,
            TagHelperOutput output)
        {
            string RoleName = "";
            IdentityUser user = await _userManager.FindByIdAsync(User);

            if (user != null)
            {
                foreach (var role in _roleManager.Roles)
                {
                    if (role != null
                    && await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        RoleName = role.Name;
                    }
                }
            }

            output.Content.SetContent(RoleName == "" ?
                "No role" : RoleName);
        }
    }
}
