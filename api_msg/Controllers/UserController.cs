using Microsoft.AspNetCore.Mvc;
using api_msg.Models;
using api_msg.Services;
using api_msg.View;
using api_msg.Models.View;

namespace api_msg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return _userService.GetUsers().ToList();
        }

        // GET: api/User/5
        [HttpGet("{name}")]
        public async Task<ActionResult<User>> GetUserName(string name)
        {
            var user = _userService.GetUserByName(name);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }



        [HttpGet("GetUserId/{id}")]
        public async Task<ActionResult<User>> GetUserID(int id)
        {
            var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }



        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        /* public async Task<IActionResult> PutUser(int id, User user)
         {
             if (id != user.Id)
             {
                 return BadRequest();
             }

             _userService.UpdateUser = EntityState.Modified;

             try
             {
                 await _context.SaveChangesAsync();
             }
             catch (DbUpdateConcurrencyException)
             {
                 if (!UserExists(id))
                 {
                     return NotFound();
                 }
                 else
                 {
                     throw;
                 }
             }

             return NoContent();
         }*/

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserView newUser)
        {

            User user = new User(newUser.Nome, newUser.Senha, newUser.Numero);

            _userService.CreateUser(user);

            return Ok(User);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
           var user = _userService.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            _userService.DeleteUser(id);

            return NoContent();
        }

    }
}
