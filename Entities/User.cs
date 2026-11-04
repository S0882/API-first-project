using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class User
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress, Required]
        public string UserEmail { get; set; }
        [Required]
        public string Password { get; set; }
        public int Id { get; set; }
    }
}
