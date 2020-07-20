using System.Linq;
using Microsoft.EntityFrameworkCore;
using Shop.Web.Data.Entities;

namespace Shop.Web.Data
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext context;

        public ProductRepository(DataContext context) : base(context)
        {
            this.context = context;
        }
        public IQueryable<Product> GetAllWithUsers()
        {
            return this.context.Products.Include(p=> p.User);
        }
    }

}
