using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public static class IdentitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        /// <summary>
        /// Seed db with admin user
        /// </summary>
        /// <param name="app"></param>
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            // retrieve the usermanager service
            UserManager<IdentityUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if(user == null)
            {
                user = new IdentityUser("admin");
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
