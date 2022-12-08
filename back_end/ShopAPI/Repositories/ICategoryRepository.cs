using ShopAPI.Data;
using ShopAPI.Models;

namespace ShopAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task<int> InsertCategory(CategoryModel categoryModel);
        Task<List<CategoryModel>> GetCategories();
    }
}
