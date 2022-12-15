using ShopAPI.Data;

namespace ShopAPI.Repositories
{
    public interface IRecipeRepository
    {
        Task<RecipeModel> GetRecipeById(int id);
        Task<RecipeModel> CreateNewRecipte(RecipeModelInput newRecipe);
    }
}
