    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    using WebAPI.Models;

    namespace WebAPI.Services
    {
        public class PageService : IPageService
        {
            private readonly string _filePath = "ProductData.json";

            public async Task<List<ProductModel>> CreateNewProduct(ProductModel model)
            {
                try
                {
                    List<ProductModel> products = await GetAllProducts();
                    products ??= new List<ProductModel>();
                    products.Add(model);
                    await WriteToFile(products);
                    return products;
                }
                catch (Exception ex)
                {
                    // Handle exception
                    throw new Exception("Error occurred while creating new product.", ex);
                }
            }

            public async Task<List<ProductModel>> DeleteProduct(int id)
            {
                try
                {
                    List<ProductModel> products = await GetAllProducts();
                    products?.RemoveAll(p => p.Id == id);
                    await WriteToFile(products);
                    return products;
                }
                catch (Exception ex)
                {
                    // Handle exception
                    throw new Exception("Error occurred while deleting product.", ex);
                }
            }

            public async Task<List<ProductModel>> GetAllProducts()
            {
                try
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
                catch (Exception ex)
                {
                    // Handle exception
                    throw new Exception("Error occurred while getting all products.", ex);
                }
            }

            public async Task<ProductModel> GetProductById(int id)
            {
                try
                {
                    List<ProductModel> products = await GetAllProducts();
                    return products?.Find(p => p.Id == id);
                }
                catch (Exception ex)
                {
                    // Handle exception
                    throw new Exception("Error occurred while getting product by ID.", ex);
                }
            }

            public async Task<ProductModel> UpdateProduct(int id, ProductModel model)
            {
                try
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
                catch (Exception ex)
                {
                    // Handle exception
                    throw new Exception("Error occurred while updating product.", ex);
                }
            }


            private async Task WriteToFile(List<ProductModel> products)
            {
                try
                {
                    string json = JsonSerializer.Serialize(products);
                    await File.WriteAllTextAsync(_filePath, json);
                }
                catch (Exception ex)
                {
                    // Handle exception
                    throw new Exception("Error occurred while writing to file.", ex);
                }
            }
        }
    }
