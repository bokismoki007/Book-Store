using BookStore.Domain.Models.Domain;
using BookStore.Repository.Interface;
using BookStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Implementation
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<BookInShoppingCart> _bookInShoppingCartRepository;

        public BookService(IRepository<Book> bookRepository, IRepository<BookInShoppingCart> bookInShoppingCartRepository)
        {
            _bookRepository = bookRepository;
            _bookInShoppingCartRepository = bookInShoppingCartRepository;
        }

        public void CreateNewBook(Book b)
        {
            _bookRepository.Insert(b);
        }

        public void DeleteBook(Guid id)
        {
            var book = _bookRepository.Get(id);
            _bookRepository.Delete(book);
        }

        public List<Book> GetAllBooks()
        {
            return _bookRepository.GetAll().ToList();
        }

        public Book GetDetailsForBook(Guid? id)
        {
            var book = _bookRepository.Get(id);
            return book;
        }

        public void UpdateExistingBook(Book b)
        {
            _bookRepository.Update(b);
        }
    }
}
