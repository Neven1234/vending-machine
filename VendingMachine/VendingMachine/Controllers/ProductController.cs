using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VendingMachine.Data;
using VendingMachine.DTOs;
using VendingMachine.Models;

namespace VendingMachine.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ProductController(IRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        //Add new product
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct( string userId, ProductDTO productDTO)
        {
            if (userId != User.FindFirstValue("userId") || User.FindFirstValue("Role") != "Seller")
            {
                return Unauthorized();
            }
           
            if (!_repository.checkDepositAndCost(productDTO.Cost))
                return BadRequest("Cost should be divisible by 5");
            await _repository.AddProduct(userId,productDTO);
            if(await _repository.SaveAll())
            {
                return Ok(productDTO);
            }
            return BadRequest();

        }
        //Update product
        [HttpPut("Update/{ProductId}")]
        public async Task<IActionResult> UpdateProduct( int ProductId,ProductDTO productDTO)
        {
            var product = await _repository.GetByIdAsync(ProductId);
            if(product==null)
            {
                return BadRequest();
            }
            if(product.SellerId!= User.FindFirstValue("userId") || User.FindFirstValue("Role") != "Seller")
            {
                return Unauthorized();
            }
            _mapper.Map(productDTO, product);
            if(await _repository.SaveAll())
            {
                return Ok(productDTO);
            }
            return BadRequest();

        }
        //Get AllProducts
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetAllProducts()
        {

            var products = await _repository.GetAllAsync();
            var ProductsToReturn = _mapper.Map<IEnumerable<ProductDTO>>(products);
            return Ok(ProductsToReturn);
        }

        //Get One Product
        [HttpGet("{id}")]
        public async Task<IActionResult>GetProduct(int id)
        {
            var product= await _repository.GetByIdAsync(id);
            if(product==null)
                return BadRequest();
            var productToReturn=_mapper.Map<ProductDTO>(product);
            return Ok(productToReturn);
        }

        //Delete product
        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteProduct(int id)
        {
            var product=await _repository.GetByIdAsync(id);
            if(product==null)
                return BadRequest();
            if(product.SellerId!=User.FindFirstValue("userId")|| User.FindFirstValue("Role") != "Seller")
                return Unauthorized();
             _repository.Delete(product);
            if(await _repository.SaveAll() )
                return Ok();
            return BadRequest();

        }

    }
}
