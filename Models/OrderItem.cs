namespace PickupExpressApp.Client.Models
{
    public class OrderItem
    {
        public int ItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        // Nav Props
        public Order? Order { get; set; }
        public Product? Product { get; set; }
    }
}