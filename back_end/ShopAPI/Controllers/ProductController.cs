﻿using Microsoft.AspNetCore.Mvc;
using ShopAPI.Data;
using ShopAPI.Models;
using ShopAPI.Repositories;
using ShopAPI.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopAPI.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepo;

        public ProductController(IProductRepository repo)
        {
            _productRepo = repo;
        }

        [HttpGet]
        [Route("api/[controller]/Products")]
        public async Task<IActionResult> GetAllProducts()
        {
            ResponseType type = ResponseType.Success;
            try
            {
                List<ProductModel> data = await _productRepo.GetProducts();
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
        [Route("api/[controller]/Products/{Id}")]
        public async Task<IActionResult> GetProductById(int Id)
        {
            ResponseType type = ResponseType.Success;
            try
            {
                DetailProductModel data = await _productRepo.GetProductById(Id);
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
        [Route("api/[controller]/Product")]
        public async Task<IActionResult> AddProduct(ProductModel model)
        {
            try
            {
                ResponseType type = ResponseType.Success;
                var result = await _productRepo.InsertProduct(model);
                if (result == 1)
                    return Ok(ResponseHandler.GetApiResponse(ResponseType.Success, model?.Name));
                else
                    return BadRequest(ResponseHandler.GetApiResponse(ResponseType.AlreadyExist, model?.Name));
            }
            catch (Exception e)
            {
                return BadRequest(ResponseHandler.GetExceptionResponse(e));
            }

        }
    }
}
