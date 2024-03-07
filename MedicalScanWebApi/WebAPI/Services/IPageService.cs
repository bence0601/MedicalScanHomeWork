using WebAPI.Models;

namespace WebAPI.Services
{
    public interface IPageService
    {
        public Task<List<ProductModel>> GetAllProducts();
        public Task<ProductModel> GetProductById(int  id);
        public Task<ProductModel> UpdateProduct(int id, ProductModel model);
        public Task<List<ProductModel>> CreateNewProduct(ProductModel model);
        public Task<List<ProductModel>> DeleteProduct(int id);

    }
}
