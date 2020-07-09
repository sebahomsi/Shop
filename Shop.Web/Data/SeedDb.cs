using Microsoft.AspNetCore.Identity;
using Shop.Web.Helpers;

namespace Shop.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Shop.Web.Data.Entities;
    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;
        private readonly IUserHelper userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.random = new Random();
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("sebita@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Seba",
                    LastName = "Homsi",
                    Email = "sebita@gmail.com",
                    UserName = "sebita@gmail.com"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!this.context.Products.Any())
            {
                this.AddProduct("First Product", user);
                this.AddProduct("Second Product", user);
                this.AddProduct("Third Product", user);
                await this.context.SaveChangesAsync();
            }
        }


        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Product
            {
                Name = name,
                Price = this.random.Next(500),
                IsAvailable = true,
                Stock = this.random.Next(50),
                User = user
            });
        }

    }
}
