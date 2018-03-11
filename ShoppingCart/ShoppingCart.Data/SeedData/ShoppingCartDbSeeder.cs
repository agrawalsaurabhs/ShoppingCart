using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ShoppingCart.Data.SeedData
{
    public class ShoppingCartDbSeeder
    {
        private readonly ShoppingDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public ShoppingCartDbSeeder(ShoppingDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        //for now we will just create an admin user
        public async Task<bool> Seed()
        {
            _dbContext.Database.EnsureCreated();

            if (!_dbContext.Roles.Any())
            {
                List<IdentityRole> identityRoles = new List<IdentityRole>
                {
                    new IdentityRole() {Name = "Admin"},
                    new IdentityRole() {Name = "User"}
                };

                foreach (IdentityRole role in identityRoles)
                {
                    await _roleManager.CreateAsync(role);
                }

                // Initialize default user
                IdentityUser admin = new IdentityUser
                {
                    Email = "admin@bcg.com",
                    UserName = "admin"
                };

                await _userManager.CreateAsync(admin, "welcome2BCG!");
                await _userManager.AddToRoleAsync(admin, "Admin");

                //Seed products data from JSON file
            }

            return true;
        }
    }
}
