using BootCart.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootCart.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        public AdminController( UserManager<ApplicationUser> userManager)

        {
            this.userManager = userManager;
        }
        [HttpGet("ProductMasterView")]
        [ProducesResponseType(typeof(IEnumerable<ApplicationUser>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ProductView()
        {
            var users = await userManager.GetUsersInRoleAsync("ProductMaster");
            if(users == null)
                return NotFound();
            return Ok(users);
        }
        [HttpGet("CustomerView")]
        [ProducesResponseType(typeof(IEnumerable<ApplicationUser>), StatusCodes.Status200OK)]
        public async Task<ActionResult> CustomerView()
        {
            var users = await userManager.GetUsersInRoleAsync("Customer");
            if (users == null)
                return NotFound();
            return Ok(users);
        }

    }
}
