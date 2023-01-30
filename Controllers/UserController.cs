using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiProof.Context;
using WebApiProof.Models; 

namespace WebApiProof.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext context; 

        public UserController(AppDbContext context) {
            this.context = context;
        }

        [HttpGet] 
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }


        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            var newUser = new User(); 

            newUser.Name = user.Name;
            newUser.Email = user.Email;
            newUser.Password = user.Password;

            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();

            return Ok();

        }
    }
}
