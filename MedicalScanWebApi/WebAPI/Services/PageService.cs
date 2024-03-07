using System.Text.Json;
using WebAPI.Models;

namespace WebAPI.Services
{
    public class PageService : IPageService
    {
        private readonly string _filePath = "ProductData.json";

        public async Task<List<ProductModel>> CreateNewProduct(ProductModel model)
        {
            List<ProductModel> products = await GetAllProducts();
            products ??= new List<ProductModel>();
            products.Add(model);
            await WriteToFile(products);
            return products;
        }

        public async Task<List<ProductModel>> DeleteProduct(int id)
        {
            List<ProductModel> products = await GetAllProducts();
            products?.RemoveAll(p => p.Id == id);
            await WriteToFile(products);
            return products;
        }

        public async Task<List<ProductModel>> GetAllProducts()
        {
            if (!File.Exists(_filePath))
            {
                return new List<ProductModel>();
            }

            using (StreamReader reader = new StreamReader(_filePath))
            {
                string json = await reader.ReadToEndAsync();
                return JsonSerializer.Deserialize<List<ProductModel>>(json);
            }
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            List<ProductModel> products = await GetAllProducts();
            return products?.Find(p => p.Id == id);
        }

        public async Task<ProductModel> UpdateProduct(int id, ProductModel model)
        {
            List<ProductModel> products = await GetAllProducts();
            int index = products.FindIndex(p => p.Id == id);
            if (index != -1)
            {
                products[index] = model;
                await WriteToFile(products);
                return model;
            }
            return null;
        }


        private async Task WriteToFile(List<ProductModel> products)
        {
            string json = JsonSerializer.Serialize(products);
            await File.WriteAllTextAsync(_filePath, json);
        }
    }
}
