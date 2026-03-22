using ECommerce.Data.Enums;
using ECommerce.Models;

namespace ECommerce.Data
{
    public class AppDbItnitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {

            using (var applicationservies = applicationBuilder.ApplicationServices.CreateScope())
            {
                // created scope manual because this is not an action
                // get context service 

                var context = applicationservies.ServiceProvider.GetService<ECommerceDBContext>();
                context.Database.EnsureCreated();

                //Category
                if (!context.Categories.Any())
                {
                    var categories = new List<Category>()
    {
        new()
        {
            Name = "Electronics",
            Description = "Electronics Description"
        },
        new()
        {
            Name = "Clothing",
            Description = "Clothing Description"
        },
        new()
        {
            Name = "Books",
            Description = "Books Description"
        },
        new()
        {
            Name = "Home Appliances",
            Description = "Home Appliances Description"
        },
        new()
        {
            Name = "Sports",
            Description = "Sports Description"
        },
        new()
        {
            Name = "Toys",
            Description = "Toys Description"
        },
        new()
        {
            Name = "Beauty",
            Description = "Beauty Description"
        },
        new()
        {
            Name = "Groceries",
            Description = "Groceries Description"
        }
    };

                    context.Categories.AddRange(categories);
                    context.SaveChanges();
                }


                //Product
                if (!context.Products.Any())
                {
                    var products = new List<Product>()
    {
        new()
        {
            Name = "Laptop",
            Description = "Laptop Description",
            ImageURL = "laptop.jpg",
            Price = 1000,
            ProductColor = ProductColor.Red,
            CategoryId = 1
        },
        new()
        {
            Name = "T-Shirt",
            Description = "T-Shirt Description",
            ImageURL = "tshirt.jpg",
            Price = 200,
            ProductColor = ProductColor.Blue,
            CategoryId = 2
        },
        new()
        {
            Name = "C# Book",
            Description = "C# Book Description",
            ImageURL = "book.jpg",
            Price = 150,
            ProductColor = ProductColor.Green,
            CategoryId = 3
        },
        new()
        {
            Name = "Microwave",
            Description = "Microwave Description",
            ImageURL = "microwave.jpg",
            Price = 800,
            ProductColor = ProductColor.Black,
            CategoryId = 4
        },
        new()
        {
            Name = "Football",
            Description = "Football Description",
            ImageURL = "football.jpg",
            Price = 120,
            ProductColor = ProductColor.White,
            CategoryId = 5
        },
        new()
        {
            Name = "Toy Car",
            Description = "Toy Car Description",
            ImageURL = "toycar.jpg",
            Price = 90,
            ProductColor = ProductColor.Yellow,
            CategoryId = 6
        },
        new()
        {
            Name = "Lipstick",
            Description = "Lipstick Description",
            ImageURL = "lipstick.jpg",
            Price = 75,
            ProductColor = ProductColor.Pink,
            CategoryId = 7
        },
        new()
        {
            Name = "Rice Pack",
            Description = "Rice Pack Description",
            ImageURL = "rice.jpg",
            Price = 50,
            ProductColor = ProductColor.Brown,
            CategoryId = 8
        }
    };

                    context.Products.AddRange(products);
                    context.SaveChanges();
                }

            }

        }

    }
}
