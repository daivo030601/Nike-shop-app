using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Data;
using ShopAPI.Repositories;
using ShopAPI.Response;

namespace ShopAPI.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;

        public UserController(IUserRepository repo)
        {
            _userRepo = repo;
        }

        [HttpGet]
        [Route("api/[controller]/Users")]
        public async Task<IActionResult> GetAllUsers()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<UserModel> data = await _userRepo.GetUsers();
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

        [HttpGet]
        [Route("api/[controller]/User/{Id}")]
        public async Task<IActionResult> GetUserById(int Id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                UserModel data = await _userRepo.GetUserById(Id);
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
        [Route("api/[controller]/User")]
        public async Task<IActionResult> AddUser(UserModel model)
        {
            try
            {
                var result = await _userRepo.InsertUser(model);
                if(result == 1)
                    return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, model.Username));
                else
                    return BadRequest(ResponseHandler.GetApiResponse(ResponseType.AlreadyExist, model.Username));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(e));
            }

        }
    }
}
