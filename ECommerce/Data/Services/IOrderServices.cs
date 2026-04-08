using ECommerce.Data.Cart;
using ECommerce.Models;

namespace ECommerce.Data.Services
{
    public interface IOrderServices
    {

        public Task StoreOrders(List<ShoppingCartItem> items, string UserId); 
        public Task<List<Order>> GetOrdersByUserIdAsync(string userId);

        
    }
}
