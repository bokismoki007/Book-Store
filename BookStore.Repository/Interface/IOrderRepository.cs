using BookStore.Domain.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetDetailsForOrder(BaseEntity id);
    }
}
