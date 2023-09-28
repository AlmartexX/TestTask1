using Microsoft.AspNetCore.Mvc;
using TestTask.Services.Interfaces;

namespace TestTask.Controllers
{
    [Route("api/v1/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        [Route("selected-orders")]
        public async Task<IActionResult> GetOrders()
        {
            var result = await this.orderService.GetOrders();
            return this.Ok(result);
        }

        [HttpGet]
        [Route("selected-order")]
        public async Task<IActionResult> GetOrder()
        {
            var result = await this.orderService.GetOrder();
            return this.Ok(result);
        }
       
    }
}
