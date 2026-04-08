using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Cart
{
    public class ShoppingCart
    {

        private readonly ECommerceDBContext _conetxt;

        public string ShoppingCartId_ { get; set; }

        public ShoppingCart(ECommerceDBContext context)
        {
            _conetxt = context;

        }
        public static ShoppingCart GetShoppingCart(IServiceProvider serviceProvider) {


            var session = serviceProvider.GetService<IHttpContextAccessor>().HttpContext.Session;
            var context = serviceProvider.GetService<ECommerceDBContext>();
            string cartId = session.GetString("CartId")??Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { 
            
            ShoppingCartId_ = cartId
            };
        
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
            => _conetxt.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId_).Include(x => x.Product).ToList();

        public decimal GetShoppingCartTotal()

            => _conetxt.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId_).Select(x => x.Quantity * x.Product.Price).Sum();

        public int GetShoppingCartTotalQuantity()

            => _conetxt.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId_).Select(x => x.Quantity ).Sum();
        public async Task AddItemToShoppingCart(Product product)
        {


            var productExisted = _conetxt.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId_ && x.ProductId == product.Id).FirstOrDefault();

            if (productExisted == null)
            {


                await _conetxt.ShoppingCartItems.AddAsync(new ShoppingCartItem
                {

                    ProductId = product.Id,
                    Quantity = 1,
                    ShoppingCartId = ShoppingCartId_,
                    Product = product


                });


            }
            else
            {

                productExisted.Quantity += 1;
            }
            await _conetxt.SaveChangesAsync();
        }

        public async Task RemoveItemFromShoppingCart(Product product)
        {
            var productExisted = _conetxt.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId_ && x.ProductId == product.Id).FirstOrDefault();

            if (productExisted != null)
            {

                if (productExisted.Quantity > 1)
                {
                    productExisted.Quantity -= 1;
                }
                else
                {

                    _conetxt.ShoppingCartItems.Remove(productExisted);

                }
                await _conetxt.SaveChangesAsync();
            }

        }


        public void ClearShoppingCart() {

            var items = _conetxt.ShoppingCartItems.Where(x => x.ShoppingCartId == ShoppingCartId_).ToList();

            _conetxt.ShoppingCartItems.RemoveRange(items); 
            _conetxt.SaveChanges();

        }
    }
}
