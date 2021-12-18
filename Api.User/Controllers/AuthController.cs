using Api.User.Auth.Business;
using Api.User.Auth.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestModel model)
        {
            var result=_authService.Login(model);
            return Ok(result);
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody]  RegisterRequestModel model)
        {
            var result = _authService.Register(model);
            return Ok(result);
        }
    }
}
