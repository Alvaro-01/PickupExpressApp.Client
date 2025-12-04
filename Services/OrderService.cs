using System.Net.Http.Json;
using System.Text.Json;
using PickupExpressApp.Client.DTOs;
using PickupExpressApp.Client.Models;

namespace PickupExpressApp.Client.Services
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpClient;

        public OrderService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET api/order
        public async Task<List<Order>> GetAllOrdersAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/order");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var orders = JsonSerializer.Deserialize<List<Order>>(content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return orders ?? new List<Order>();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Could not load orders.", e);
            }
        }

        // GET api/order/status/{status}
        public async Task<List<Order>> GetOrdersByStatusAsync(OrderStatus status)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/order/status/{status}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var orders = JsonSerializer.Deserialize<List<Order>>(content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return orders ?? new List<Order>();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not load {status} orders.", e);
            }
        }

        // GET api/order/user/{userId}
        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/order/user/{userId}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var orders = JsonSerializer.Deserialize<List<Order>>(content,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return orders ?? new List<Order>();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not load orders for user #{userId}.", e);
            }
        }

        // GET api/order/{id}
        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/order/{id}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var order = JsonSerializer.Deserialize<Order>(content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return order;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not load order with id {id}.", e);
            }
        }

        // POST api/order
        public async Task<Order?> CreateOrderAsync(OrderCreateDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/order", dto);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Order>();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Could not create order.", e);
            }
        }

        // PATCH: api/order/{id}/status
        public async Task<Order?> UpdateOrderStatusAsync(int id, OrderStatus newStatus)
        {
            try
            {
                var dto = new OrderStatusUpdateDto { NewStatus = newStatus };

                var response = await _httpClient.PatchAsJsonAsync($"api/order/{id}/status", dto);

                return await response.Content.ReadFromJsonAsync<Order>();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not update the status for order #{id}", e);
            }
        }
        
        // DELETE: api/order/{id}
        public async Task<bool> DeleteOrderAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/order/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not delete order #{id}", e);
            }
        }
    }
}