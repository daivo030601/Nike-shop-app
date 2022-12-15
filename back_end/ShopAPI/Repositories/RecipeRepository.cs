using Microsoft.EntityFrameworkCore;
using ShopAPI.Data;
using AutoMapper;
using ShopAPI.Models;

namespace ShopAPI.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RecipeRepository (DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }

        public async Task<RecipeModel> CreateNewRecipte(RecipeModelInput newRecipe)
        {
            var recipe = _mapper.Map<Recipe>(newRecipe);
            if (recipe == null)
                return new RecipeModel();
            await _context.recipes.AddAsync(recipe);
            await _context.SaveChangesAsync();

            return _mapper.Map<RecipeModel>(recipe);
        }

        public async Task<RecipeModel> GetRecipeById(int id)
        {
            var recipe = await _context.recipes.FindAsync(id);
            RecipeModel recipeModel = _mapper.Map<RecipeModel>(recipe);
            var listRecipeItem = await _context.recipeItems.Where(x => x.RecipeId == id).ToListAsync();
            List<RecipeItemModel> listRecipeItemModel = new List<RecipeItemModel>();
            var recipeItems = (from p in _context.products
                               join ri in _context.recipeItems on p.ProductId equals ri.ProductId
                               where ri.RecipeId == id
                               select new RecipeItemModel
                               {
                                   RecipeId = ri.RecipeId,
                                   Quatity = ri.Quatity,
                                   ProductId = p.ProductId,
                                   ProductName = p.Name,
                                   Price = p.Price,
                                   Total = (ri.Quatity * p.Price)
                               }).ToList();
            foreach(var item in recipeItems)
            {
                listRecipeItemModel.Add(item);
            }

            recipeModel.RecipeItemModels = listRecipeItemModel;

            return recipeModel;
        }
    }
}
