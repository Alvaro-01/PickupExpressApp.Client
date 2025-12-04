using PickupExpressApp.Client.DTOs;
using PickupExpressApp.Client.Models;

namespace PickupExpressApp.Client.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<List<Order>> GetOrdersByStatusAsync(OrderStatus status);
        Task<Order?> GetOrderByIdAsync(int id);

        // Employee Operations
        Task<Order?> CreateOrderAsync(OrderCreateDto dto);
        Task<Order?> UpdateOrderStatusAsync(int id, OrderStatus newStatus);
        Task<bool> DeleteOrderAsync(int id);
    }
}