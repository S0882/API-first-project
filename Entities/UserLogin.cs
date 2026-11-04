using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class UserLogin
    {
        [EmailAddress, Required]
        public string UserLogEmail { get; set; }
        [Required]
        public string LogPassword { get; set; }
    }
}
