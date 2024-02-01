using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public string? Quantity { get; set; }
        public string? SubTotal { get; set; }
        public Order Order { get; set; }
    }
}
