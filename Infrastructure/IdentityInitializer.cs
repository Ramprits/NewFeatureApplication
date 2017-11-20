using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using New_Application.Models;

namespace New_Application.Infrastructure {
    public class IdentityInitializer {

        public UserManager<ApplicationUser> _userMgr;

        private readonly RoleManager<IdentityRole> _roleMgr;
        public IdentityInitializer (UserManager<ApplicationUser> userMgr, RoleManager<IdentityRole> roleMgr) {
            _userMgr = userMgr;
            _roleMgr = roleMgr;
        }
        public async Task Seed () {
            var user = await _userMgr.FindByNameAsync ("Rampritsahani");

            // Add User
            if (user == null) {
                // if (!(await _roleMgr.RoleExistsAsync ("Admin"))) {
                //     var role = new IdentityRole ("Admin");
                //     role.Claims.Add (new IdentityRoleClaim<string> () { ClaimType = "IsAdmin", ClaimValue = "True" });
                //     await _roleMgr.CreateAsync (role);
                // }

                user = new ApplicationUser () {
                    UserName = "Ramprit",
                    FirstName = "Ramprit",
                    LastName = "Sahani",
                    Email = "Rampritsahani@outlook.in"
                };

                var userResult = await _userMgr.CreateAsync (user, "P@ssw0rd!");
                var roleResult = await _userMgr.AddToRoleAsync (user, "Admin");
                var claimResult = await _userMgr.AddClaimAsync (user, new Claim ("SuperUser", "True"));

                if (!userResult.Succeeded || !roleResult.Succeeded || !claimResult.Succeeded) {
                    throw new InvalidOperationException ("Failed to build user and roles");
                }

            }
        }
    }
}