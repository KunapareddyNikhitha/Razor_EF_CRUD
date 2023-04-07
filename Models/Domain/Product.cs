using System.ComponentModel.DataAnnotations;

namespace Razor_EF_CRUD.Models.Domain
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Availability { get; set; }
        public string Category { get; set; }
    }
}
