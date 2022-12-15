using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Repositories;
using ShopAPI.Data;
using ShopAPI.Response;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeItemRepository _recipeItemRepository;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeController(IRecipeItemRepository recipeItemRepository, IRecipeRepository recipeRepository)
        {
            _recipeItemRepository = recipeItemRepository;
            _recipeRepository = recipeRepository;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetRecipeByID(int id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                RecipeModel recipe = await _recipeRepository.GetRecipeById(id);
                if(recipe == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, recipe));                    
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(e));
            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateRecipe(RecipeModelInput recipeModel)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                RecipeModel newRecipe = await _recipeRepository.CreateNewRecipte(recipeModel);
                if(newRecipe != null)
                {
                    type = ResponseType.Failure;
                }    
                foreach(var item in recipeModel!.RecipeItemModelInputs)
                {
                    RecipeItemModel recipeItem = await _recipeItemRepository.CreateRecipeItem(item, newRecipe!.RecipeId);
                    newRecipe.RecipeItemModels.Add(recipeItem);
                }    
                return Ok(ResponseHandler.GetApiResponse(type, newRecipe));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(e));
            }
        }
    }
}
