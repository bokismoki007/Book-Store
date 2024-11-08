using BookStore.Domain.Models.Domain;
using BookStore.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using static System.Reflection.Metadata.BlobBuilder;

namespace BookStore.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IShoppingCartService _shoppingCartService;

        public BooksController(IBookService bookService, IShoppingCartService shoppingCartService, IAuthorService authorService)
        {
            _bookService = bookService;
            _shoppingCartService = shoppingCartService;
            _authorService = authorService;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = _bookService.GetAllBooks();


            foreach (var book in books)
            {
                book.Author = _authorService.GetDetailsForAuthor(book.AuthorId);
            }
            return View(books);
        }

        // GET: Books/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetDetailsForBook(id);
            if (book == null)
            {
                return NotFound();
            }
            var authors = _authorService.GetAllAuthors();
            ViewData["AuthorId"] = new SelectList(authors, "Id", "Id");

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            var authors = _authorService.GetAllAuthors();
            ViewData["AuthorId"] = new SelectList(authors, "Id", "Id"); 
            return View();
        }

        // POST: Books/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("AuthorId,Title,Genre,Year,Image,Price,Id")] Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = Guid.NewGuid();
                _bookService.CreateNewBook(book);
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetDetailsForBook(id);
            if (book == null)
            {
                return NotFound();
            }

            var authors = _authorService.GetAllAuthors();
            ViewData["AuthorId"] = new SelectList(authors, "Id", "Id", book.AuthorId);

            return View(book);
        }

        // POST: Books/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("AuthorId,Title,Genre,Year,Image,Price,Id")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bookService.UpdateExistingBook(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _bookService.GetDetailsForBook(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _bookService.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddToCart(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _bookService.GetDetailsForBook(id);

            BookInShoppingCart ps = new BookInShoppingCart();

            if (product != null)
            {
                ps.BookId = product.Id;
            }

            return View(ps);
        }
        [HttpPost]
        public IActionResult AddToCartConfirmed(BookInShoppingCart model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            _shoppingCartService.AddToShoppingConfirmed(model, userId);

            return View("Index", _bookService.GetAllBooks());
        }
    }
}
