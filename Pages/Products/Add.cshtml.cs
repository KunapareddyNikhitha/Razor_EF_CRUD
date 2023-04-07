using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_EF_CRUD.Data;
using Razor_EF_CRUD.Models.Domain;
using Razor_EF_CRUD.Models.ViewModels;

namespace Razor_EF_CRUD.Pages.Products
{
    public class AddModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;

        public AddModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [BindProperty]
        public AddProductViewModel AddProductRequest { get; set; }
        public void OnGet()
        { 
        }
        public void OnPost()
        {
            //Convert ViewModel to DomainModel
            var productDomainModel = new Product
            {
                Name = AddProductRequest.Name,
                Price = AddProductRequest.Price,
                Availability = AddProductRequest.Availability,
                Category = AddProductRequest.Category
            };
            dbContext.Products.Add(productDomainModel);
            //dbcontext.tablename.Add Method
            dbContext.SaveChanges();

            ViewData["Message"] = "Product added Successfully";
        }
    }
}
