namespace Domain.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? TotalAmount { get; set; }
        public bool? OrderStatus { get; set; } //pending and delivered
        public AppUser? AppUser { get; set; }
        public List<OrderItem>? Items { get; set; }
    }
}
