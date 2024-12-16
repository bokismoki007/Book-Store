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
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;

        public OrderService(IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public List<Order> GetAllOrders()
        {
            return _orderRepository.GetAllOrders();
        }

        public List<Order> GetAllOrdersForUser(string userId)
        {
            var loggedInUser = _userRepository.Get(userId);
            return this.GetAllOrders().Where(order => order.Owner.Email == loggedInUser.Email).ToList();
        }

        public Order GetDetailsForOrder(Guid? id)
        {
            return _orderRepository.GetDetailsForOrder(id);
        }
    }
}
