using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_EF_CRUD.Data;
using Razor_EF_CRUD.Models.ViewModels;

namespace Razor_EF_CRUD.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;
        [BindProperty]
        public EditProductViewModel EditProductViewModel { get; set; }
        public EditModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet(Guid id)
        {
            var product = dbContext.Products.Find(id);
            if (product != null)
            {
                //Convert Domain model to view model
                EditProductViewModel = new EditProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Availability = product.Availability,
                    Category = product.Category

                };
            }
            
        }

        public void OnPostUpdate()
        {
            if (EditProductViewModel != null)
            {
                var existingProduct = dbContext.Products.Find(EditProductViewModel.Id);
                if (existingProduct != null)
                {
                    //Convert ViewModel to Domain Model
                    existingProduct.Name = EditProductViewModel.Name;
                    existingProduct.Price = EditProductViewModel.Price;
                    existingProduct.Availability = EditProductViewModel.Availability;
                    existingProduct.Category = EditProductViewModel.Category;
                    dbContext.SaveChanges();
                    ViewData["UpdateMessage"] = "Product Details Updated Successfully";
                }
                
                
            }
        }

        public IActionResult OnPostDelete()
        {
            var existingProduct = dbContext.Products.Find(EditProductViewModel.Id);
            if(existingProduct != null)
            {
                dbContext.Products.Remove(existingProduct);
                dbContext.SaveChanges();
                //ViewData["DeleteMessage"] = "Product Details Updated Successfully";

                return RedirectToPage("/Products/List");
            }
            return Page();
        }
    }
}
