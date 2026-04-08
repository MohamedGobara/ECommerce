using ECommerce.Data.Cart;
using ECommerce.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class OrdersController : Controller
    {

        private readonly IProductServices _services;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderServices _orderServices;

        public OrdersController(IProductServices services, ShoppingCart shoppingCart, IOrderServices orderServices, IProductServices productServices)
        {
            _services=services;
            _shoppingCart=shoppingCart;
            _orderServices=orderServices;
           
        }


        public async Task<IActionResult> Index()
        {
            string userId = "";
            var orders = await _orderServices.GetOrdersByUserIdAsync(userId);
            return View(orders);
        }
        public IActionResult ShoppingCart()
        {
            var shoppingCartItems   =  _shoppingCart.GetShoppingCartItems();
            ViewBag.Total = _shoppingCart.GetShoppingCartTotal();
            return View(shoppingCartItems);
        }
        public IActionResult ShoppingCartProductsIndex()
        {
            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();
           
            return RedirectToAction("Index","Products");
        }



        public async Task<IActionResult> AddToCart(int id) { 
        
        var item  = await _services.GetByIdAsync(id);
            if (item!=null) {
            
            
                await _shoppingCart.AddItemToShoppingCart(item);
            
            }
            return RedirectToAction(nameof(ShoppingCartProductsIndex));
        
        }


        public async Task<IActionResult> RemoveitemFromCart(int id)
        {

            var item = await _services.GetByIdAsync(id);
            if (item != null)
            {


                await _shoppingCart.RemoveItemFromShoppingCart(item);

            }
            return RedirectToAction(nameof(ShoppingCart));

        }

        public async Task<IActionResult> CompleteOrder() {

            var items = _shoppingCart.GetShoppingCartItems();
            string userId = "";

            await _orderServices.StoreOrders(items, userId);

            _shoppingCart.ClearShoppingCart();
            return View(); 
        
        }


       

    }
}
