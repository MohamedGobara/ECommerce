using ECommerce.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class CategoriesController : Controller
    {
        

        private readonly ECommerceDBContext _eCommerceDBContext;
        public CategoriesController(ECommerceDBContext eCommerceDBContext)
        {
            _eCommerceDBContext = eCommerceDBContext;


        }
        public async Task<IActionResult> Index()
        {
            var categories = await _eCommerceDBContext.Categories.ToListAsync();
            return View("Index", categories);
        }
    }
}
