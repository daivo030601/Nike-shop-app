using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopAPI.Data;
using ShopAPI.Repositories;
using ShopAPI.Response;

namespace ShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepo;

        public AddressController(IAddressRepository repo)
        {
            _addressRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<AddressModel> data = await _addressRepo.GetAddress();
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
    }
}
