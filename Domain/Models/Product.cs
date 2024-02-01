using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Enum;

namespace Domain.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public string? StockQuantity { get; set; }
        public string? ProductImageUrl { get; set; }
        public ProductCategory? ProductCategory { get; set; }
        [ForeignKey("Category")]
        public List<Category>? Category { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
