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

        UserService _userService = new UserService();

        // GET: api/<User>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _userService.Get();
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            if(_userService.Get(id) != null)
                return Ok(_userService.Get(id));
            
            return NoContent();
        }

        // POST api/<User>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            user = _userService.Post(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id },user);
        }

      
        [HttpPost("Login")]
        public ActionResult<UserLogin> Post([FromBody] UserLogin loginUser)
        {
            if(_userService.Login(loginUser) != null)
                return Ok(_userService.Login(loginUser));

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User userToUpdate)
        {
            _userService.Put(id, userToUpdate);  
            return Ok();
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
