using Microsoft.EntityFrameworkCore;
using ShopAPI.Data;
using ShopAPI.Models;
using AutoMapper;

namespace ShopAPI.Repositories
{
    public class RecipeItemRepository : IRecipeItemRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RecipeItemRepository(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }
        public async Task<RecipeItemModel> CreateRecipeItem(RecipeItemModelInput newRecipeItemModel, int recipeId)
        {
            var recipeItem = _mapper.Map<RecipeItem>(newRecipeItemModel);
            recipeItem.RecipeId = recipeId;
            if (recipeItem == null)
                return new RecipeItemModel();
            await _context.recipeItems.AddAsync(recipeItem); 
            await _context.SaveChangesAsync();
            return _mapper.Map<RecipeItemModel>(recipeItem);
        }
    }
}
