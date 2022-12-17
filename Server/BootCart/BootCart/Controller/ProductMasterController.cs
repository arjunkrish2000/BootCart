using BootCart.Model.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootCart.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMasterController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly SignInManager<ApplicationUser> signinManager;

        public ProductMasterController(
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

        [HttpPost("AddProduct")]
        [ProducesResponseType(typeof(Address), StatusCodes.Status200OK)]

        public async Task<IActionResult> Post(ProductViewModel model)
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return BadRequest();
            }
            db.Products.Add(new Product()
            {
                ProductType=model.ProductType,
                ProductCategory=model.ProductCategory,
                AddedDate=model.PurchaseDate,
                ProductImage=model.ProductImage
            });
            return Ok(model);
        }
       

    }
}
