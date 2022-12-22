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
            return Ok(model);
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

        public async Task<IActionResult> ViewStock()
        {
            var id = HttpContext.User.FindFirstValue("UserId");
            var stock = await db.Products.Where(i => i.ApplicationUserId == id).ToListAsync() ;
            return Ok(stock);
        }

        [HttpGet("ViewInStockProducts")]

        public async Task<IActionResult> ViewInStockProducts()
        {
            var id = HttpContext.User.FindFirstValue("UserId");
            var stock = await db.ProductSpecifications.Include(i => i.Products).Where(i => i.UserId == id).ToListAsync();
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


        public class UploadImageRequest
        {
            public IFormFile ImageFile { get; set; }
            public string Title { get; set; }
        }



        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] UploadImageRequest uploadImageRequest)
        {
            string path = Path.Combine(Environment.CurrentDirectory, "ProductImages");
            string fileName = Guid.NewGuid().ToString();



            bool folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);



            if (uploadImageRequest.ImageFile.Length > 0)
            {
                string filePath = Path.Combine(path, fileName + Path.GetExtension(uploadImageRequest.ImageFile.FileName));
                using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await uploadImageRequest.ImageFile.CopyToAsync(fileStream);
                }
            }



            //Store fileName , extension , imageTitle into product master table



            return Ok("Image Uploaded");
        }
    }
}

  
