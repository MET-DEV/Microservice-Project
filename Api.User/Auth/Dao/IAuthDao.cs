using Api.User.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.User.Auth.Dao
{
    public interface IAuthDao
    {
        public bool CheckUser(LoginRequestModel model);
        public void Add(RegisterRequestModel model);
    }
}
