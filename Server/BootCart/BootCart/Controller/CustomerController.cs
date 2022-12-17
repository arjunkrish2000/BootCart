using BootCart.Model.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootCart.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signinManager;

        public CustomerController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager, IConfiguration configuration,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signinManager)

        {
            this.db = context;
            this.userManager = userManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
            this.signinManager = signinManager;
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
             PostOffice=model.PostOffice,
             Pincode=model.Pincode,
             City=model.City,
             District=model.District,
             State=model.State,
             LandMark=model.LandMark,
             AlternateMobileNumber=model.AlternateMobileNumber,
             Type=model.Type,
             UserId=user.Id
            });
            return Ok(model);
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
        public async Task<IActionResult> PutAddress(Address model)
        {
            var Adrs = await db.Addresses.FindAsync(model.Id);
            if (Adrs == null)
                return NotFound();
            Adrs.Id = model.Id;
            Adrs.Name = model.Name;
            Adrs.HouseName= model.HouseName;
            Adrs.PostOffice=model.PostOffice;
            Adrs.City=model.City;
            Adrs.District=model.District;
            Adrs.State=model.State;
            Adrs.LandMark=model.LandMark;
            Adrs.AlternateMobileNumber=model.AlternateMobileNumber;
            Adrs.Type=model.Type;


            await db.SaveChangesAsync();
            return Ok(Adrs);
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


    }
}
