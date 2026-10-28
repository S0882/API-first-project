using System.ComponentModel.DataAnnotations;

namespace WEB_API
{
    //Simple names are clearer here: Email and Password (the class name already says it's for login)
    public class UserLogin
    {
        [Required]
        [EmailAddress]
        public string UserLogEmail { get; set; }
        [Required]
        public string LogPassword { get; set; }
    }
}
