using BookStore.Domain.Models.Domain;
using BookStore.Domain.Models.Domain.DTO;
using BookStore.Repository.Interface;
using BookStore.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Service.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<EmailMessage> _emailMessageRepository;
        private readonly IRepository<BookInShoppingCart> _bookInShoppingCartRepository;
        private readonly IRepository<BookInOrder> _bookInOrderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;

        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IRepository<Book> bookRepository, IRepository<Order> orderRepository, IRepository<BookInShoppingCart> bookInShoppingCartRepository, IRepository<BookInOrder> bookInOrderRepository, IUserRepository userRepository, IRepository<EmailMessage> emailRepository, IEmailService emailService)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _bookRepository = bookRepository;
            _orderRepository = orderRepository;
            _bookInShoppingCartRepository = bookInShoppingCartRepository;
            _bookInOrderRepository = bookInOrderRepository;
            _userRepository = userRepository;
            _emailMessageRepository = emailRepository;
            _emailService = emailService;
        }

        public bool AddToShoppingConfirmed(BookInShoppingCart model, string userId)
        {
            if (userId == null)
                return false;


            var loggedInUser = _userRepository.Get(userId);
            var shoppingCart = loggedInUser?.UserCart;

            if (shoppingCart.BooksInShoppingCart == null)
                shoppingCart.BooksInShoppingCart = new List<BookInShoppingCart>();

            shoppingCart.BooksInShoppingCart.Add(model);
            model.ShoppingCartId = shoppingCart.Id;
            _shoppingCartRepository.Update(shoppingCart);
            return true;
        }

        public bool deleteBookFromShoppingCart(string userId, Guid productId)
        {
            if (userId == null)
                return false;

            var loggedInUser = _userRepository.Get(userId);
            var userShoppingCart = loggedInUser?.UserCart;
            var product = userShoppingCart?.BooksInShoppingCart.Where(x => x.BookId == productId).FirstOrDefault();

            userShoppingCart.BooksInShoppingCart.Remove(product);
            _shoppingCartRepository.Update(userShoppingCart);
            return true;
        }

        public ShoppingCartDto getShoppingCartInfo(string userId)
        {
            var loggedInUser = _userRepository.Get(userId);
            var userShoppingCart = loggedInUser?.UserCart;
            var allProduct = userShoppingCart?.BooksInShoppingCart?.ToList();

            var totalPrice = allProduct.Select(x => (x.Book.Price * x.Quantity)).Sum();

            ShoppingCartDto dto = new ShoppingCartDto
            {
                Books = allProduct,
                TotalPrice = totalPrice
            };
            return dto;
        }

        public bool order(string userId)
        {
            if (userId == null)
                return false;

            var loggedInUser = _userRepository.Get(userId);

            var userShoppingCart = loggedInUser?.UserCart;
            EmailMessage message = new EmailMessage();
            message.Subject = "Successfull book order";
            message.MailTo = loggedInUser.Email;
            Order order = new Order
            {
                Id = Guid.NewGuid(),
                OwnerId = userId,
                Owner = loggedInUser
            };

            List<BookInOrder> productsInOrder = new List<BookInOrder>();

            var rez = userShoppingCart.BooksInShoppingCart.Select(
                z => new BookInOrder
                {
                    Id = Guid.NewGuid(),
                    BookId = z.Book.Id,
                    Book = z.Book,
                    OrderId = order.Id,
                    Order = order,
                    Quantity = z.Quantity
                }).ToList();


            StringBuilder sb = new StringBuilder();

            var totalPrice = 0.0;

            sb.AppendLine("Your order is completed. The order conatins: ");

            for (int i = 1; i <= rez.Count(); i++)
            {
                var currentItem = rez[i - 1];
                totalPrice += currentItem.Quantity * currentItem.Book.Price;
                sb.AppendLine(i.ToString() + ". " + currentItem.Book.Title + " with quantity of: " + currentItem.Quantity + " and price of: $" + currentItem.Book.Price);
            }

            sb.AppendLine("Total price for your order: " + totalPrice.ToString());
            message.Content = sb.ToString();

            productsInOrder.AddRange(rez);

            foreach (var product in productsInOrder)
            {
                _bookInOrderRepository.Insert(product);
            }

            loggedInUser.UserCart.BooksInShoppingCart.Clear();
            _userRepository.Update(loggedInUser);
            this._emailService.SendEmailAsync(message);

            return true;
        }
    }
}
