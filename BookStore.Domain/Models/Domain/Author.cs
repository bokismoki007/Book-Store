using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Models.Domain
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Biography { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
