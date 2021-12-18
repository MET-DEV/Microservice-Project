using Api.User.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.User.Auth.Business
{
    public interface IAuthService
    {
        public LoginResponseModel Login(LoginRequestModel model);
        public RegisterResponseModel Register(RegisterRequestModel model);
    }
}
