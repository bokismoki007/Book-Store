using BookStore.Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models.Domain
{
    public class Book : BaseEntity
    {
        public Guid AuthorId { get; set; }
        public virtual Author? Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
        public virtual BookStoreUser? CreatedBy { get; set; }
        public virtual ICollection<BookInShoppingCart>? BooksInShoppingCart { get; set; }
        public ICollection<BookInOrder>? BooksInOrder { get; set; }
    }
}
