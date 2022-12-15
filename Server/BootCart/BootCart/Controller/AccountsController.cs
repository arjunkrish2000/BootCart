using System.Collections;
using BootCart.Model.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BootCart.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager, IConfiguration configuration,
            RoleManager<IdentityRole> roleManager)

        {
            this.db = context;
            this.userManager = userManager;
            this.configuration = configuration;
            this.roleManager = roleManager;
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
                UserName = Guid.NewGuid().ToString().Replace("-", "")
            };
            var role = Convert.ToString(model.UserTypes);
            var res = await userManager.CreateAsync(user);
            if (!res.Succeeded)
                return BadRequest(res);
            if (model.UserTypes== 0)
            {
                db.CustomerDetails.Add(new CustomerDetail()
                {
                    UserId = user.Id,
                    AlternateEmail = model.Email
                });
            }
            await userManager.AddToRoleAsync(user, role);
            return Ok(user);
            return Ok(model);
        }
     
        [HttpGet ]
        public async Task<IActionResult> GenerateData()
        {
            await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
            await roleManager.CreateAsync(new IdentityRole() { Name = "Customer" });
            await roleManager.CreateAsync(new IdentityRole() { Name = "Seller" });

            var users = await userManager.GetUsersInRoleAsync("Admin");
            if (users.Count == 0)
            {
                var appUser = new ApplicationUser()
                {
                    FirstName = "Admin",
                    LastName = "User",
                    Email = "admin@admin.com",
                    UserName = "admin",
                };
                var res = await userManager.CreateAsync(appUser, "Pass@123");
                await userManager.AddToRoleAsync(appUser, "Admin");
            }
            return Ok("Data generated");
        }
    }
}
