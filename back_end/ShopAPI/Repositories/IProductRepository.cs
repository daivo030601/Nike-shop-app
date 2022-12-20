using ShopAPI.Data;

namespace ShopAPI.Repositories
{
    public interface IProductRepository
    {
        Task<int> InsertProduct(ProductModel productModel);
        Task<List<ProductModel>> GetProducts();
        Task<List<ProductModel>> GetProductsByCollection(int CollectionId);
        Task<int> DeleteProduct(int productId);
        Task UpdateProduct(ProductModel product);
        Task<DetailProductModel> GetProductById(int Id);
    }
}
