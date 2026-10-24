using System.ComponentModel.DataAnnotations;

namespace WEB_API
{
    public class User
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public int Id { get; set; }
    }
}
