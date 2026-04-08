using ECommerce.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Views.Shared.Components.ShoppingCartSummary
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart; 
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke() {

            var totalQuantity = _shoppingCart.GetShoppingCartTotalQuantity();
            ViewBag.TotalAmount = _shoppingCart.GetShoppingCartTotal();
            return View(totalQuantity); 
        }
    }
}
