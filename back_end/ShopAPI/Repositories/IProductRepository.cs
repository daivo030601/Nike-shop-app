using ShopAPI.Data;

namespace ShopAPI.Repositories
{
    public interface IProductRepository
    {
        Task<int> InsertProduct(ProductModel productModel);
        Task<List<ProductModel>> GetProducts();
        Task<DetailProductModel> GetProductById(int Id);
    }
}
