using BootCart.Model.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BootCart.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductMasterController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public ProductMasterController(ApplicationDbContext context)

        {
            this.db = context;
        }

        [HttpPost("AddProduct")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddProduct(ProductViewModel model)
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
            }) ;
            await db.SaveChangesAsync();
            return Ok("Product details succesfully added");
        }

        [HttpPost("AddProductSpecification")]
        [ProducesResponseType(typeof(ProductSpecification), StatusCodes.Status200OK)]

        public async Task<IActionResult> AddProductSpecification(ProductSpecificationModel model)
        {
            var id = HttpContext.User.FindFirstValue("UserId");

            db.ProductSpecifications.Add(new ProductSpecification()
            {
               Color = model.Color,
               Material = model.Material,
               Size = model.Size,
               ItemQuantity = model.ItemQuantity,
               UserId = id,
               ProductId = model.Pid
            });
            await db.SaveChangesAsync();
            return Ok(model);
        }

        [HttpGet("ViewStock")]

        public async Task<IActionResult> Viewstock()
        {
            var id = HttpContext.User.FindFirstValue("UserId");
            var stock = await db.ProductSpecifications.Include(i => i.Products).Where(i => i.UserId == id).ToListAsync() ;
            return Ok(stock);
        }
     

        [HttpPut("UpdateProduct")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> UpdateProduct(ProductViewModel model)
        {
            var prdct = await db.Products.FindAsync(model.Id);
            if (prdct == null)
                return NotFound();
            prdct.ProductType = model.ProductType;
            prdct.ProductCategory = model.ProductCategory;
            prdct.Quantity = model.Quantity;
            prdct.ProductImage = model.ProductImage;
            prdct.AddedDate = DateTime.Now;
            prdct.Price = model.Price;
            await db.SaveChangesAsync(); 
            return Ok();
        }
    }
}

  
