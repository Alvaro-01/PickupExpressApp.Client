using PickupExpressApp.Client.Models;

namespace PickupExpressApp.Client.DTOs
{
    public class OrderStatusUpdateDto
    {
        public OrderStatus NewStatus { get; set; }
    }
}