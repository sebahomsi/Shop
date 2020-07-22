using System.ComponentModel.DataAnnotations;

namespace Shop.Web.Data.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => $"{this.FirstName} {this.LastName}";
    }
}
