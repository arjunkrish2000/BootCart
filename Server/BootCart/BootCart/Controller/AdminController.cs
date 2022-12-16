using BootCart.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootCart.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public AdminController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager, IConfiguration configuration,
            RoleManager<IdentityRole> roleManager)

        {
            this.db = context;
            this.userManager = userManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
        }
        [HttpGet("ProductMasterView")]
        [ProducesResponseType(typeof(IEnumerable<ApplicationUser>), StatusCodes.Status200OK)]
        public async Task<ActionResult> ProductView()
        {
            var users = await userManager.GetUsersInRoleAsync("ProductMaster");
            return Ok(users);
        }
        [HttpGet("CustomerView")]
        [ProducesResponseType(typeof(IEnumerable<ApplicationUser>), StatusCodes.Status200OK)]
        public async Task<ActionResult> CustomerView()
        {
            var users = await userManager.GetUsersInRoleAsync("Customer");
            return Ok(users);
        }

    }
}
