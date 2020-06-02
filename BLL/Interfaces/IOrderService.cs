using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Models;

namespace BLL.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderModel>> GetAll();
        Task CreateOrderAsync(OrderModel orderModel);
    }
}