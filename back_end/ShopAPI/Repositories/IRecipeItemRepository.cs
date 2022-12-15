using ShopAPI.Data;

namespace ShopAPI.Repositories
{
    public interface IRecipeItemRepository
    {
        Task<RecipeItemModel> CreateRecipeItem(RecipeItemModelInput newRecipeItemModel, int recipeId);
    }
}
