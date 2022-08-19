using GeekShopping.CartAPI.Data.ValueObjects;
using GeekShopping.CartAPI.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.CartAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartRepository _cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
        }

        [HttpGet("find-cart/{id}")]
        public async Task<ActionResult<CartVO>> FindByCart(string userId)
        {
            var cart = await _cartRepository.FindCartByUserId(userId);

            if (cart == null)
                return NotFound();
            else
                return Ok(cart);
        }

        [HttpPost("add-cart")]
        public async Task<ActionResult<CartVO>> AddCart([FromBody] CartVO cartVO)
        {
            if (cartVO == null) return BadRequest();
            var cart = await _cartRepository.SaveOurUpdateCart(cartVO);
            return Ok(cart);
        }

        [HttpPut("update-cart")]
        public async Task<ActionResult<CartVO>> UpdateCart([FromBody] CartVO cartVO)
        {
            if (cartVO == null) return BadRequest();
            var cart = await _cartRepository.SaveOurUpdateCart(cartVO);
            return Ok(cart);
        }

        [HttpDelete("remove-cart")]
        public async Task<ActionResult<bool>> RemoveCart(int id)
        {
            var status = await _cartRepository.RemoveFromCart(id);
            if (!status) BadRequest(); 
            return Ok(status);
        }
    }
}
