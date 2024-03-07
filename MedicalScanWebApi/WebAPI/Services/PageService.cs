using WebAPI.Models;

namespace WebAPI.Services
{
    public class PageService : IPageService
    {
        public Task<List<ProductModel>> CreateNewProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductModel>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> UpdateProduct(int id, ProductModel model)
        {
            throw new NotImplementedException();
        }
    }
}
