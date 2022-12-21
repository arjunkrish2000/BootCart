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
        [HttpPost("AddAddress")]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]



        public async Task<IActionResult> AddAddress(AddressViewModel model)
        {
            var user = await userManager.GetUserAsync(User);



            if (user == null)
            {
                return BadRequest();
            }
            db.Addresses.Add(new Address()
            {

                Name = model.Name,
                HouseName = model.HouseName,
                PostOffice = model.PostOffice,
                Pincode = model.Pincode,
                City = model.City,
                District = model.District,
                State = model.State,
                LandMark = model.LandMark,
                AlternateMobileNumber = model.AlternateMobileNumber,
                Type = model.Type,
                UserId = user.Id
            });
            return Ok("Address Added");
        }
        [HttpGet("GetAddress")]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        public async Task<Address> GetAddress(int id)
        {
            return await db.Addresses.FindAsync(id);
        }
        [HttpPut("UpdateAddress")]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAddress(Address model)
        {
            var Adrs = await db.Addresses.FindAsync(model.Id);
            if (Adrs == null)
                return NotFound();
            Adrs.Id = model.Id;
            Adrs.Name = model.Name;
            Adrs.HouseName = model.HouseName;
            Adrs.PostOffice = model.PostOffice;
            Adrs.City = model.City;
            Adrs.District = model.District;
            Adrs.State = model.State;
            Adrs.LandMark = model.LandMark;
            Adrs.AlternateMobileNumber = model.AlternateMobileNumber;
            Adrs.Type = model.Type;
            await db.SaveChangesAsync();
            return Ok("Address Updated");
        }
        [HttpDelete("DeleteAddress")]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAddress(int Id)
        {
            var address = await db.Addresses.FindAsync(Id);
            if (address == null)
            {
                return NotFound();
            }
            db.Addresses.Remove(address);
            await db.SaveChangesAsync();
            return Ok(address);
        }
        [HttpPost("AddOrderItem")]
        [ProducesResponseType(typeof(OrderItem), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddOrderItem(OrderItemModel model)
        {
            var id = HttpContext.User.FindFirstValue("UserId");

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
            Items.UserId = "28626f60-35d1-488d-aecf-0e750b0b7d19";
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
    }   
}
