using ECommerce.Data;
using ECommerce.Data.Services;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class CategoriesController : Controller
    {
        

        private readonly CategoryServices _categoryServices;
        public CategoriesController(CategoryServices categoryServices)
        {
            _categoryServices = categoryServices;


        }
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryServices.GettAllAsync();
            return View( categories);
        }


        [HttpGet()]
        public IActionResult Create() { 
        
        
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> Create([Bind("Name,Description")]Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryServices.CreateAsync(category);
            }
            else {
                return View(category);
            }

              return View();
        }

        


        [HttpGet()]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryServices.GetByIdAsync(id);
            if (category!=null) {
                return View("Edit", category);
            }
            return View("PageNotFound");
        }

        [HttpPost]
        public async Task<IActionResult> Update(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryServices.UpdateAsync(category);
                return RedirectToAction("Index");
            }
            else {

                return View("Edit", category);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryServices.DeleteAsync(id);
            return RedirectToAction("Index");
        }


    }
}
