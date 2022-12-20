using BootCart.Model.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]

        public async Task<IActionResult> Post(ProductViewModel model)
        {
            var id = HttpContext.User.FindFirstValue("UserId");
            
            db.Products.Add(new Product()
            {
                ProductType = model.ProductType,
                ProductCategory = model.ProductCategory,
                Quantity = model.Quantity,
                ProductImage = model.ProductImage,
                AddedDate = DateTime.Now,
                Price = model.Price,
                ApplicationUserId = id
            });
            db.SaveChanges();
            return Ok(model);
        }

        [HttpPost("AddProductSpecification")]
        [ProducesResponseType(typeof(ProductSpecification), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddProductSpecification(ProductViewModel model,int pid)
        {
            var id = HttpContext.User.FindFirstValue("UserId");

            db.ProductSpecifications.Add(new ProductSpecification()
            {
               Color = model.Color,
               Material = model.Material,
               Size = model.Size,
               ItemQty = model.ItemQty,
               ProductId = pid
            });
            db.SaveChanges();
            return Ok(model);
        }

        [HttpGet("ViewStock")]

        public async Task<IActionResult> Viewstock()
        {
            var id = HttpContext.User.FindFirstValue("UserId");
            var stock = db.Products.Where(i => i.ApplicationUserId == id);
            return Ok(stock);
        }

    }
}
