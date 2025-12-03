using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickupExpressApp.Client.DTOs;
using PickupExpressApp.Client.Models;

namespace PickupExpressApp.Client.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<List<Product>> GetAvailableProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);

        // Employee Operations
        Task<Product?> CreateProductAsync(ProductCreateDto dto);
        Task<Product?> UpdateProductAsync(ProductUpdateDto dto);
        Task<Product?> UpdateQuantityInStockAsync(int id, int newQuantity);
        Task<bool> DeleteProductAsync(int id);
    }
}
