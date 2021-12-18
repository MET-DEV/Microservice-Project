using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.User.Auth.Models
{
    public class RegisterResponseModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
