using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers
{
    
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderModel>>> GetAll()
        {
            return Ok(await _orderService.GetAll());
        }

        [HttpPost]
        public async Task<ActionResult<OrderModel>> CreeateOrder(OrderModel model)
        {
            await _orderService.CreateOrderAsync(model);
            return Ok(model);
        }

    }
}