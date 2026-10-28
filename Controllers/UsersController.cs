using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    //fix: The file is renamed to UsersController.cs, so it matches the class
    public class UsersController : ControllerBase
    {
        //fix: The path never changes, so it can be readonly
        static readonly string FilePath = "User.txt";

        // GET: api/<User>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<User>/5
        [HttpGet("{id}")]
        public ActionResult<WEB_API.User> Get(int id)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                        return Ok(user);
                }
            }
            return NoContent();
        }

        // POST api/<User>
        [HttpPost]
        public ActionResult<WEB_API.User> Post([FromBody] WEB_API.User user)
        {
            int numberOfUsers = System.IO.File.ReadLines(FilePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(FilePath, userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.Id },user);
        }

      
        //The assignment asks a wrong login to return NoContent() (204)
        [HttpPost("Login")]
        public ActionResult<WEB_API.UserLogin> Post([FromBody] WEB_API.UserLogin loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(FilePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    WEB_API.User user =
                    JsonSerializer.Deserialize<WEB_API.User>(currentUserInFile);
                    if (user.UserEmail == loginUser.UserLogEmail && user.Password ==
                    loginUser.LogPassword)
                        return Ok(user);
                }
            }

            return NotFound();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        public void Put(int id, [FromBody] User userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(FilePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User user =
                    JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (user.Id == id)
                    {
                        textToReplace = currentUserInFile;
                        //fix: Found- break
                        break;
                    }
                }
            }
            if(textToReplace != string.Empty)
{
                //fix: Keep the id, otherwise the updated user is saved without it
                userToUpdate.Id = id;
                string text = System.IO.File.ReadAllText(FilePath);
                text = text.Replace(textToReplace,
                JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(FilePath, text);
            }
        }

        // DELETE api/<User>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
