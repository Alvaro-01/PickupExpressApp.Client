using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using PickupExpressApp.Client.DTOs;
using PickupExpressApp.Client.Models;

namespace PickupExpressApp.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET api/product
        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/product");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<List<Product>>(content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return products ?? new List<Product>();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Could not load products.", e);
            }
        }

        // GET api/product/available
        public async Task<List<Product>> GetAvailableProductsAsync()
        {

            try
            {
                var response = await _httpClient.GetAsync("api/product/available");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var products = JsonSerializer.Deserialize<List<Product>>(content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return products ?? new List<Product>();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Could not load products.", e);
            }
        }

        // GET api/product/{id}
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/product/{id}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var product = JsonSerializer.Deserialize<Product>(content,
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return product;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not load product with id {id}.", e);
            }
        }

        // POST api/product
        public async Task<Product?> CreateProductAsync(ProductCreateDto dto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/product", dto);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<Product>();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Could not create product.", e);
            }
        }

        // PUT api/product/{id}
        public async Task<Product?> UpdateProductAsync(ProductUpdateDto dto)
        {
            try
            {
                if (dto.ProductId == 0)
                {
                    throw new InvalidOperationException("Product must exist to be updated");
                }

                var response = await _httpClient.PutAsJsonAsync($"api/product/{dto.ProductId}", dto);
                response.EnsureSuccessStatusCode();
                
                return await response.Content.ReadFromJsonAsync<Product>();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Could not create product.", e);
            }
        }

        // PATCH api/product/{id}/quantity
        public async Task<Product?> UpdateQuantityInStockAsync(int id, int newQuantity)
        {
            try
            {
                var dto = new ProductStockUpdateDto { NewQuantity = newQuantity };

                var response = await _httpClient.PatchAsJsonAsync($"api/product/{id}/quantity", dto);

                return await response.Content.ReadFromJsonAsync<Product>();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not update the quantity for the product with id {id}", e);
            }
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/product/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Could not delete product with id {id}", e);
            }
        }
    }
}