using System.ComponentModel.DataAnnotations;

namespace EMartProject.Models
{
    public class UserDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Location { get; set; }


    }
}
