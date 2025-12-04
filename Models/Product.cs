namespace PickupExpressApp.Client.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public int QuantityInStock { get; set; }

        // Nav Property
        public List<OrderItem>? OrderItems { get; set; }
    }
}