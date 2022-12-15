using System.Collections;
using BootCart.Model.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootCart.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager)
        {
            this.db = context;
            this.userManager = userManager;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequestModel model)
        {
            var user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                UserName = new Guid().ToString().Replace("-", "")
            };
            var res = await userManager.CreateAsync(user);
            if (!res.Succeeded)
                return BadRequest(res);

            db.CustomerDetails.Add(new CustomerDetail()
            {
                UserId = user.Id,
                AlternateEmail = model.Email
            });

            await db.SaveChangesAsync();
            return Ok(user);
            return Ok(model);
        }
    }
}
