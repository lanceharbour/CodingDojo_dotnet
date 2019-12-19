using System.ComponentModel.DataAnnotations;

namespace LoginReg
{
    public class Credential
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}