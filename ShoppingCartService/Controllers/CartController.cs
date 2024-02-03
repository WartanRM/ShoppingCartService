using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ShoppingCartService.Models;
using ShoppingCartService.Models.DTO;
using ShoppingCartService.Services;

namespace ShoppingCartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ShoppingCartContext _context;
        private readonly TracksService _tracksService;

        public CartController(ShoppingCartContext context, TracksService tracksService)
        {
            _context = context;
            _tracksService = tracksService;
        }

        // Get all cart items for a user
        [HttpGet]
        public ActionResult<IEnumerable<CartItem>> GetCartItems(int userId)
        {
            return _context.CartItems.Where(c => c.UserId == userId).ToList();
        }

        // Add a track to the cart
        [HttpPost]
        public ActionResult AddToCart([FromBody] CartItem cartItem)
        {
            ValidateCartItem(cartItem);

            var track = _tracksService.GetTrackById(cartItem.TrackId);
            if (track == null)
            {
                return BadRequest("Track not found");
            }

            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCartItems), new { id = cartItem.Id }, cartItem);
        }

        // Update a cart item's quantity
        [HttpPut("{id}")]
        public ActionResult UpdateCartItem(int id, [FromBody] CartItem cartItem)
        {
            // Find the cart item
           

            _context.Update(cartItem);
            _context.SaveChanges();
            return NoContent();
        }

        // Remove a cart item
        [HttpDelete("{id}")]
        public ActionResult RemoveCartItem(int id)
        {
            // Find the cart item

            _context.CartItems.Remove(CartItem);
            _context.SaveChanges();
            return NoContent();
        }

        // Get the total price of the cart
        [HttpGet("total")]
        public ActionResult<int> GetCartTotal(int userId)
        {
            // Calculate total price based on cart items
           
        }

        private void ValidateCartItem(CartItem cartItem)
        {
            if (cartItem.Quantity <= 0)
            {
                throw new InvalidOperationException("Quantity must be greater than 0");
            }
        }
    }
}