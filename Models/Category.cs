using System.ComponentModel.DataAnnotations;

namespace Day3_LaVanHien.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name is between 2 <= x <= 100")]
        public string? Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
