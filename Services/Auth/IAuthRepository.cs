using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Drive.Models;
using Microsoft.AspNetCore.Mvc;

namespace Drive.Services.Auth
{
    public interface IAuthRepository
    {
        User Login(string UserName, string Password);
        string GenerateToken (User User);
        void LogOutAsync();
        IEnumerable<User> GetAll();
    }

}