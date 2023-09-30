using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Product.API.Business.Interfaces;
using Product.API.Dto;
using Product.API.Entity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Product.API.Controllers
{
    [ApiController]
    [Route("/product")]
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("search")]
        [ProducesDefaultResponseType(typeof(List<Entity.Product>))]
        public List<Entity.Product> Search([FromBody]SearchProductsRequestDto getProductRequestDto)
        {
            return _productService.SearchProducts(getProductRequestDto);
        }

        [HttpGet("getAll")]
        [ProducesDefaultResponseType(typeof(List<Entity.Product>))]
        public IEnumerable<Entity.Product> Get()
        {
            return _productService.GetProducts();
        }

        [HttpPost("save")]
        [ProducesDefaultResponseType(typeof(bool))]
        public bool Save([FromBody] SaveProductRequestDto saveProductRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }
            return _productService.Save(saveProductRequestDto);
        }

        [HttpDelete("delete")]
        [ProducesDefaultResponseType(typeof(bool))]
        public bool Delete([FromBody] int productId)
        {
            _productService.Delete(productId);
            return true;
        }
    }
}

