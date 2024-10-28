using BookStore.Domain.Models.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models.Identity
{
    public class BookStoreUser : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public ShoppingCart? UserCart { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
