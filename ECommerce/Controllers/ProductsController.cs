using ECommerce.Data;
using ECommerce.Data.Services;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        public ProductsController(IProductServices productServices , ICategoryServices categoryServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;


        }
        public async Task<IActionResult> Index()
        {
            var products = await _productServices.GettAllAsync(x => x.Category);
            return View("Index", products);
        }

        public async Task<IActionResult> Details(int id) { 
        
            var product =  await _productServices.GetByIdAsync(id , x =>x.Category);
            return View(product); 
        
        
        }



        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewBag.Categories = await  _categoryServices.GettAllAsync();

            return View();


        }



        [HttpPost]
        public async Task<IActionResult> Create(Product product) {



            product.ProductColor = Data.Enums.ProductColor.Green;
            if (ModelState.IsValid) {

               await  _productServices.CreateAsync(product);
                return RedirectToAction("Index");
            
            }
            return View(product);


        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Categories = await _categoryServices.GettAllAsync();
            var product = await _productServices.GetByIdAsync(id,(p)=>p.Category);
         

           return View(product);


        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            await _productServices.UpdateAsync(product);


            return RedirectToAction("Index");


        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {


            await _productServices.DeleteAsync(id);
            return RedirectToAction("Index");

        }


    }
}
