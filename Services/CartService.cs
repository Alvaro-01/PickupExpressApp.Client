using Blazored.LocalStorage;
using PickupExpressApp.Client.Models;

namespace PickupExpressApp.Client.Services
{
    public class CartService
    {
        private readonly ILocalStorageService _localStorage;
        private readonly IProductService _productService;
        private const string CartKey = "cart";

        public CartService(ILocalStorageService localStorage, IProductService productService)
        {
            _localStorage = localStorage;
            _productService = productService;
        }

        // Get cart
        public async Task<Dictionary<int, int>> GetCartAsync()
        {
            return await _localStorage.GetItemAsync<Dictionary<int, int>>(CartKey)
                ?? new Dictionary<int, int>();
        }

        // Add 1 quantity of product
        public async Task AddToCartAsync(int productId)
        {
            // Product checks before adding to cart
            var product = await _productService.GetProductByIdAsync(productId);

            if (product == null || product.QuantityInStock <= 0)
            {
                return;
            }

            var cart = await GetCartAsync();

            if (cart.ContainsKey(productId))
            {
                if (cart[productId] >= product.QuantityInStock)
                    return;

                cart[productId]++;
            }
            else
            {
                cart[productId] = 1;
            }

            await _localStorage.SetItemAsync(CartKey, cart);
        }

        // Save cart
        public async Task SaveCartAsync(Dictionary<int, int> cart)
        {
            await _localStorage.SetItemAsync(CartKey, cart);
        }

        // Remove product from cart
        public async Task RemoveAsync(int productId)
        {
            var cart = await GetCartAsync();

            if (cart.ContainsKey(productId))
            {
                cart.Remove(productId);
                await _localStorage.SetItemAsync(CartKey, cart);
            }
        }

        public async Task ClearCartAsync()
        {
            var cart = await GetCartAsync();
            cart.Clear();
            await _localStorage.SetItemAsync(CartKey, cart);
        }
    }
}