using System.Security.Claims;
using BootCart.Model.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BootCart.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public CustomerController(
            ApplicationDbContext context, UserManager<ApplicationUser> userManager)

        {
            this.db = context;
            this.userManager = userManager;
        }


        [HttpPost("AddOrderItem")]
        [ProducesResponseType(typeof(OrderItem), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddOrderItem(OrderItemModel model)
        {
            var id = HttpContext.User.FindFirstValue("UserId");
            if (id == null)
                return NotFound();

            db.OrderItems.Add(new OrderItem()
            {
                UserId= id,
                ProductId=1,
                Quantity=model.Quantity,
                IndividulaItemPrice=model.IndividulaItemPrice
            });    
           await db.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("UpdateOrderItem")]
        [ProducesResponseType(typeof(OrderItem), StatusCodes.Status200OK)]

        public async Task<IActionResult> UpdateOrderItem(OrderItemModel model)
        {
            var id = HttpContext.User.FindFirstValue("UserId");
            var Items = await db.OrderItems.FindAsync(model.Id);
            if (Items == null)
                return NotFound();
            Items.UserId = id;
            Items.ProductId = 1;
            Items.Quantity = model.Quantity;
            Items.IndividulaItemPrice = model.IndividulaItemPrice;
            await db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("DeleteOrderItem")]
        [ProducesResponseType(typeof(OrderItem), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteOrderItem(int Id)
        {
            var Item = await db.OrderItems.FindAsync(Id);
            if (Item == null)
            {
                return NotFound();
            }
            db.OrderItems.Remove(Item);
            await db.SaveChangesAsync();
            return Ok("The corresponding item is deleted");
        }
        [HttpGet("ViewOrderItem")]

        public async Task<IActionResult> ViewOrderItem()
        {
            var id = HttpContext.User.FindFirstValue("UserId");
            var orderItems = db.OrderItems.Where(i => i.UserId == id);
            // var stock = await db.Products.ToListAsync();
            return Ok(orderItems);
        }
        [HttpPost("Addtocart")]
        [ProducesResponseType(typeof(OrderItem), StatusCodes.Status200OK)]

        public async Task<IActionResult> Addtocart(CartModel model)
        {
            var id = HttpContext.User.FindFirstValue("UserId");
            if (id == null)
                return NotFound();

            db.Carts.Add(new Cart()
            {
                UserId =id,
                ProductId = 3,
                Quantity = model.Quantity,
            });

            await db.SaveChangesAsync();
            return Ok("Added to cart");
        }
        [HttpPut("UpdateCart")]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]

        public async Task<IActionResult> UpdateCart(CartModel model)
        {
            var id = HttpContext.User.FindFirstValue("UserId");
            var Items = await db.Carts.FindAsync(model.Id);
            if (Items == null)
                return NotFound();
            Items.UserId = id;
            Items.ProductId = 3;
            Items.Quantity = model.Quantity;
            await db.SaveChangesAsync();
            return Ok("Updated the cart");
        }
        [HttpDelete("DeleteCart")]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCart(int Id)
        {
            var Cart = await db.Carts.FindAsync(Id);
            if (Cart == null)
            {
                return NotFound();
            }
            db.Carts.Remove(Cart);
            await db.SaveChangesAsync();
            return Ok("The corresponding cart is deleted");
        }
        [HttpGet("ViewCart")]

        public async Task<IActionResult> ViewCart()
        {
            var id = HttpContext.User.FindFirstValue("UserId");
            var Cart = db.Carts.Where(i => i.UserId == id);
           // var stock = await db.Products.ToListAsync();
            return Ok(Cart);
        }
        [HttpPost("PlaceOrder")]
        [ProducesResponseType(typeof(OrderItem), StatusCodes.Status200OK)]

        public async Task<IActionResult> PlaceOrder(OrderModel model)
        {
            var id = HttpContext.User.FindFirstValue("UserId");
            if (id == null)
                return NotFound();

            db.Orders.Add(new Order()
            {
               CustomerId = id,
               OrderedDate = DateTime.Now,
               DeliveryDate=model.DeliveryDate,
               Address = model.Address,
               TotalAmount = model.TotalAmount,
               Status="Pending"
            });
            await db.SaveChangesAsync();
            return Ok("PlacedOrder");
        }
        
    }   
}
