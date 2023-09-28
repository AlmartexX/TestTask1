using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Services
{
    public class OrderService:IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context
                ?? throw new ArgumentNullException();
        }

        public async Task<Order> GetOrder() =>
            await _context.Orders
            .OrderByDescending(o => o.Price * o.Quantity)
            .FirstOrDefaultAsync();

        public async Task <List<Order>> GetOrders() =>
            await _context.Orders
            .Where(o => o.Quantity > 10)
            .AsNoTracking()
            .ToListAsync();

    }
}
