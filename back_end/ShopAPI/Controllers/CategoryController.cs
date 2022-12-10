using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Data;
using ShopAPI.Models;
using ShopAPI.Repositories;
using ShopAPI.Response;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository repo)
        {
            _categoryRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<CategoryModel> data = await _categoryRepo.GetCategories();
                if (data == null)
                {
                    type = ResponseType.NotFound;
                }
                return Ok(ResponseHandler.GetApiResponse(type, data));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(e));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                var newCategoryId = await _categoryRepo.InsertCategory(model);
                return Ok(ResponseHandler.GetApiResponse(type, model.Description));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(e));
            }
            
        }
    }
}
