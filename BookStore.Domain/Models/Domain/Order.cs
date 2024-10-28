using BookStore.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models.Domain
{
    public class Order : BaseEntity
    {
        public string? OwnerId { get; set; }
        public BookStoreUser? Owner { get; set; }
        public ICollection<BookInOrder>? BooksInOrder { get; set; }
    }
}
