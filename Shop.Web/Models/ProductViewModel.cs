using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Shop.Web.Data.Entities;

namespace Shop.Web.Models
{
    public class ProductViewModel : Product
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
