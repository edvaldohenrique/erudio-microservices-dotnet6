﻿using GeekShooping.ProductAPI.Data.ValueObjects;
using GeekShooping.ProductAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShooping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new 
                ArgumentNullException(nameof(productRepository));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);

            if(product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _productRepository.FindAll();
            return Ok(products);
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Create(ProductVO productVO)
        {
            if (productVO == null) return BadRequest();
            var products = await _productRepository.Create(productVO);
            return Ok(products);
        }

        [HttpPut]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Update(ProductVO productVO)
        {
            if (productVO == null) return BadRequest();
            var products = await _productRepository.Update(productVO);
            return Ok(products);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<ProductVO>>> Delete(long id)
        {
            if (id == 0) return NotFound();
            var status = await _productRepository.Delete(id);
            return Ok(status);
        }
    }
}
