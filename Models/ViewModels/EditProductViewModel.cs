namespace Razor_EF_CRUD.Models.ViewModels
{
    public class EditProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Availability { get; set; }
        public string Category { get; set; }
    }
}
