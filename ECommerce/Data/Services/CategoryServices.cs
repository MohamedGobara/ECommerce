using ECommerce.Data.Base;
using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data.Services
{
    public class CategoryServices : EntityBaseRepository<Category>, ICategoryServices
    {
        public CategoryServices(ECommerceDBContext context) :base(context)
        {
            
        }
      
    }
}
