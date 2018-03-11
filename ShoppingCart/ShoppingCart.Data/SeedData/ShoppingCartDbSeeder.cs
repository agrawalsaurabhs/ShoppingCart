using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Newtonsoft.Json;
using ShoppingCart.Core.Domain;

namespace ShoppingCart.Data.SeedData
{
    public class ShoppingCartDbSeeder
    {
        private readonly ShoppingDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;

        public ShoppingCartDbSeeder(ShoppingDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
        }

        //for now we will just create an admin user
        //Where you don't need to return anything just return a Task, Task<void> is dangerous
        public async Task Seed()
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
            }
            if (!_dbContext.Users.Any())
            {
                // Initialize default user
                ApplicationUser admin = new ApplicationUser
                {
                    Email = "admin@bcg.com",
                    UserName = "admin"
                };

                await _userManager.CreateAsync(admin, "welcome2BCG!");
                await _userManager.AddToRoleAsync(admin, "Admin");
            }

            if (!_dbContext.Products.Any())
            {
                var path = Path.Combine(_hostingEnvironment.ContentRootPath, "SeedData/Product.json");
                var json = File.ReadAllText(path);
                var products = JsonConvert.DeserializeObject<Product>(json);
                await _dbContext.Products.AddRangeAsync(products);
                await _dbContext.SaveChangesAsync();
            }


        }
    }
}
