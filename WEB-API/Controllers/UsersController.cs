using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entities;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {

        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<User>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _userService.Get();
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            User? user = await _userService.GetAsync(id);
            if(user != null)
                return Ok(user);
            
            return NotFound();
        }

        // POST api/<User>
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            user = await _userService.PostAsync(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id },user);
        }

      
        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login([FromBody] UserLogin loginUser)
        {
            User? user = await _userService.LoginAsync(loginUser);
            if(user!= null)
                return Ok(user);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] User userToUpdate)
        {
            await _userService.PutAsync(id, userToUpdate);  
            return Ok();
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }
    }
}
