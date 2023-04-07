using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor_EF_CRUD.Data;

namespace Razor_EF_CRUD.Pages.Products
{
    public class ListModel : PageModel
    {
        private readonly RazorPagesDemoDbContext dbContext;
        public List<Models.Domain.Product> products { get; set; }
        public ListModel(RazorPagesDemoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            products = dbContext.Products.ToList();
        }
    }
}
