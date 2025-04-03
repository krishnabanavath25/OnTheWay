using System.ComponentModel.DataAnnotations;

namespace OnTheWay.Models.Authentication
{
    public class LoginModelApiconsume
    {
        [Required(ErrorMessage = "User Name is required")]
        public string? Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
