using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Data;
using ShopAPI.Repositories;
using ShopAPI.Response;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionRepository _collectionRepo;

        public CollectionController(ICollectionRepository repo) 
        {
            _collectionRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCollection()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<CollectionModel> data = await _collectionRepo.GetCollections();
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
        public async Task<IActionResult> AddCollection(CollectionModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                var newCategory = await _collectionRepo.InsertCollection(model);
                return Ok(ResponseHandler.GetApiResponse(type, model.Name));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(e));
            }

        }
    }
}
