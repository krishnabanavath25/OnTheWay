using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Domain.Entities
{
    public class Registration
    {
        public class UserModel
        {
            public string? Username { get; set; }
            public string? Gender { get; set; }
            public long? PhoneNo { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
        }
        public class LoginModel
        {
            [Required(ErrorMessage = "User Name is required")]
            public string? Username { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string? Password { get; set; }
        }
        public static class UserRoles
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }
        public class Response
        {
            public string? Status { get; set; }
            public string? Message { get; set; }
        }
    }
}
