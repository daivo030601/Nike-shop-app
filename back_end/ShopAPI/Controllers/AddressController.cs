using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Data;
using ShopAPI.Repositories;
using ShopAPI.Response;

namespace ShopAPI.Controllers
{
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepo;

        public AddressController(IAddressRepository repo)
        {
            _addressRepo = repo;
        }

        [HttpGet]
        [Route("api/[controller]/Addresses/{userId}")]
        public async Task<IActionResult> GetAllAddresses(string userId)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<AddressModel> data = await _addressRepo.GetAddress(userId);
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
        [Route("api/[controller]/Address")]
        public async Task<IActionResult> AddAddress(AddressModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                var newAddress = await _addressRepo.InsertAddress(model);
                return Ok(ResponseHandler.GetApiResponse(type, newAddress));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(e));
            }

        }

        [HttpPut]
        [Route("api/[controller]/Address")]
        public async Task<ActionResult> UpdateAddress([FromBody] AddressModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                await _addressRepo.UpdateAddress(model);
                return Ok(ResponseHandler.GetApiResponse(type, model));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }

        // DELETE 
        [HttpDelete]
        [Route("api/[controller]/Address/{id}")]
        public async Task<ActionResult> DeleteAddress(int id)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                int result = await _addressRepo.DeleteAddress(id);
                return Ok(ResponseHandler.GetApiResponse(type, "Delete success "));
            }
            catch (Exception ex)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(ex));
            }
        }
    }
}
