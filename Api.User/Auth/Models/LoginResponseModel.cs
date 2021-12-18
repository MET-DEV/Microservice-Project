using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.User.Auth.Models
{
    public class LoginResponseModel
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
