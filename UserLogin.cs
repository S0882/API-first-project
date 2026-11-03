using System.ComponentModel.DataAnnotations;

namespace WEB_API
{
    public class UserLogin
    {
        [Required]
        [EmailAddress]
        public string UserLogEmail { get; set; }
        [Required]
        public string LogPassword { get; set; }
    }
}
