using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ECommerceDBContext _eCommerceDBContext;
        public ProductsController(ECommerceDBContext eCommerceDBContext)
        {
            _eCommerceDBContext  = eCommerceDBContext; 


        }
        public async Task<IActionResult> Index()
        {
            var products  =  await _eCommerceDBContext.Products.Include(x=>x.Category).OrderBy(x=>x.Price).ToListAsync();
            return View("Index",products);
        }
    }
}
