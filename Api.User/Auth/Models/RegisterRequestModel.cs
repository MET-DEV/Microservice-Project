using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.User.Auth.Models
{
    public class RegisterRequestModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
