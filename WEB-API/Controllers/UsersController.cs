using Microsoft.AspNetCore.Mvc;
//This using isn't used in this file: you can remove it
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

        //The assignment asks the users controller to take the password service's interface and call it: where would you get the password service here?
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
            //Where should the password strength check go? The assignment asks POST to return 400 when the score is below 3, before the user is saved
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
            //Where should the password strength check go? The assignment asks PUT to return 400 when the score is below 3, before the user is updated
            _userService.Put(id, userToUpdate);  
            //Why does PUT return 500 instead of updating the user? Follow the call into the repository's Put: what happens when it reads the data file?
            return Ok();
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
