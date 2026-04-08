using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Services
{
    public class OrderServices : IOrderServices
    {
        ECommerceDBContext _context; 
        public OrderServices(ECommerceDBContext context)
        {
            _context=context;
        }
        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        => await _context.Orders.Include(x=>x.OrderItems).ThenInclude(x=>x.Product).Where(x=>x.UserId == userId).ToListAsync();

        public async Task StoreOrders(List<ShoppingCartItem> items, string UserId)
        {
            var totalPrice  = items.Select(x => x.Quantity * x.Product.Price).Sum();
            var order = new Order() { UserId = UserId ,Amount=(double)totalPrice }; 
            await _context.Orders.AddAsync(order); 
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {

                    Quantity = item.Quantity , 
                    Price = (double)item.Product.Price ,
                    OrderId = order.Id , 
                    ProductId  = item.Product.Id

                };
                await _context.OrderItems.AddAsync(orderItem); 

            }
        await _context.SaveChangesAsync();
        }

        
    }
}
