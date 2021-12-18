using Api.User.Auth.Dao;
using Api.User.Auth.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Api.User.Auth.Business
{
    public class AuthService : IAuthService
    {
        public IAuthDao _authDao;
        public AuthService(IAuthDao authDao)
        {
            _authDao = authDao;
        }
        public LoginResponseModel Login(LoginRequestModel model)
        {
            if (_authDao.CheckUser(model))
            {
                LoginResponseModel response = new LoginResponseModel { Email = model.Email, Token = GenerateToken(model) };
                return response;
            }
            return new LoginResponseModel() { Email="null", Token="null"};
        }
        public RegisterResponseModel Register(RegisterRequestModel model)
        {
            _authDao.Add(model);
            return new RegisterResponseModel() { FullName = model.FirstName + " " + model.LastName, Email = model.Email, Token = GenerateToken(new LoginRequestModel() { Email = model.Email }) };
        }






        public string GenerateToken(LoginRequestModel model)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,model.Email),
                new Claim(ClaimTypes.Name,model.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("KeyforIdentitymodel141itissoscreetkeynobodynothearthis"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expriy = DateTime.Now.AddDays(7);
            var token = new JwtSecurityToken(claims:claims, expires: expriy, signingCredentials: creds, notBefore: DateTime.Now);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedJwt;

        }

        
    }
}
