using BookStore.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Interface
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetDetailsForBook(Guid? id);
        void CreateNewBook(Book b);
        void UpdateExistingBook(Book p);
        void DeleteBook(Guid id);
    }
}
