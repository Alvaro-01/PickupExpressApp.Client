using PickupExpressApp.Client.Models;

namespace PickupExpressApp.Client.DTOs
{
    public class OrderCreateDto
    {
        public int CustomerId { get; set; }

        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public DateTime OrderDate { get; set; }

        public List<OrderItemCreateDto> OrderItems { get; set; } = new List<OrderItemCreateDto>();
    }
}