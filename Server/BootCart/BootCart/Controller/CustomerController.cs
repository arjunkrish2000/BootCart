using System.Reflection;
using System.Security.Claims;
using BootCart.Model.RequestModels;
using BootCart.Model.ResponseModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BootCart.Controller
{
    //[Authorize(Roles = "Customer")]
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public CustomerController(
            ApplicationDbContext db, UserManager<ApplicationUser> userManager)

        {
            this.db = db;
            this.userManager = userManager;
        }


        [HttpPost("AddOrderItem")]
        [ProducesResponseType(typeof(OrderItem), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddOrderItem(OrderItemModel model)
        {
            var id = HttpContext.User.FindFirstValue("UserId");
            if (id == null)
                return NotFound();
            //var product = db.ProductSpecifications.ToListAsync();
            //foreach(var item in product)
            //{
            //    if(item)
            //}
            db.OrderItems.Add(new OrderItem()
            {
                UserId= id,
               // ProductId=1,
                Quantity=model.Quantity,
                IndividulaItemPrice=model.IndividulaItemPrice
            });
            var Item = await db.Carts.FindAsync(model.ProductId);
            db.Carts.Remove(Item);
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
           // Items.ProductId = 1;
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
        [HttpGet("AddToCart/{id}")]
        [ProducesResponseType(typeof(OrderItem), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddToCart(int id)
        {
            var userId = HttpContext.User.FindFirstValue("UserId");

            //var product = await db.ProductSpecifications.FindAsync(model.ProductId); ;

            //if (id == null)
            //    return NotFound();

            db.Carts.Add(new Cart()
            {
                UserId = userId,
                ProductId = id,
            });

            await db.SaveChangesAsync();
            return Ok(id);
        }
        //[HttpPut("UpdateCart")]
        //[ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]

        //public async Task<IActionResult> UpdateCart(CartModel model)
        //{
        //    var id = HttpContext.User.FindFirstValue("UserId");
        //    var Items = await db.Carts.FindAsync(model.Id);
        //    if (Items == null)
        //        return NotFound();

        //    Items.UserId = id;
        //    Items.ProductId = 3;                
        //    await db.SaveChangesAsync();
        //    return Ok("Updated the cart");
        //}
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
            var cart = await db.Carts.Include(i => i.ProductSpecification).ThenInclude(i => i.Products).Where(i => i.UserId == id).ToListAsync();
            return Ok(cart);
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
               Status="Pending",

            });
            await db.SaveChangesAsync();
            return Ok("PlacedOrder");
        }
        [HttpGet("ViewOrder")]

        public async Task<IActionResult> ViewOrder()
        {
            var id = HttpContext.User.FindFirstValue("UserId");
            var Cart = db.Orders.Where(i => i.CustomerId == id);
            return Ok(Cart);
        
        }

        [HttpGet("ViewProducts")]

        public async Task<IActionResult> ViewProducts()
        {

            var stock = await db.ProductSpecifications.Include(i => i.Products).Where(i => i.ItemQuantity > 0).ToListAsync();
            return Ok(stock);

        }

        //[HttpPut("UpdateProfile")]
        //[ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]

        //public async Task<IActionResult> UpdateProfile(RegisterRequestModel model)
        //{
        //    var user = await db.ApplicationUsers.FindAsync(model.Id);
        //    if (user == null)
        //        return NotFound();
        //    user.FirstName = model.FirstName;
        //    user.LastName = model.LastName;
        //    user.Email = model.Email;
        //    user.Gender = model.Gender;
        //    user.PhoneNumber = model.PhoneNumber;
        //    user.DateOfBirth = model.DateOfBirth;
        //    await db.SaveChangesAsync();
        //    return Ok(user);
        //}
        //Get User Details
        [HttpGet("GetUser")]
        [ProducesResponseType(typeof(RegisterRequestModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUser()
        {
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var logedinuser = await userManager.FindByNameAsync(userName);
            var user = new RegisterRequestModel()
            {
                FirstName = logedinuser.FirstName,
                LastName = logedinuser.LastName,
                Email = logedinuser.Email,
                PhoneNumber= logedinuser.PhoneNumber,
            
            };
            return Ok(new ResponseModel<RegisterRequestModel>()
            {
                Data = user,
            });
        }
        //Updating User Details
        [HttpPut("UpdateProfile")]
        [ProducesResponseType(typeof(UpdateProfileModel), StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProfile(UpdateProfileModel model)
        {
            var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByNameAsync(userName);

            if (user == null)
                return NotFound();
            user.FirstName = model.firstName;
            user.LastName = model.lastName;
            user.PhoneNumber = model.phoneNumber;
            user.Email = model.email;
            await db.SaveChangesAsync();
            return Ok(user);
        }
   
    }
}
