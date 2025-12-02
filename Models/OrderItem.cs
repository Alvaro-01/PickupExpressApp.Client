namespace PickupExpressApp.Client.Models
{
    public class OrderItem
    {
        public int ItemId { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public required Product Product { get; set; }
    }
}