using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.Web.Data.Entities;

namespace Shop.Web.Data.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable<Product> GetAllWithUsers();
        IEnumerable<SelectListItem> GetComboProducts();
    }

}
