namespace PickupExpressApp.Client.Models
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Completed,
        PickedUp,
        Cancelled
    }

    public class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime OrderDate { get; set; }

        //nav props
        public User? Customer { get; set; }
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}