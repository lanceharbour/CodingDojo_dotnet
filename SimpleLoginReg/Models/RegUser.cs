using System.ComponentModel.DataAnnotations;

namespace SimpleLoginReg
{
    public class RegUser
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage="Passwords doesn't match")]
        [DataType(DataType.Password)]
        public string ConfPassword { get; set; }
    }
}