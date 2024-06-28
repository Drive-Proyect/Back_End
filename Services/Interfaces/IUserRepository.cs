using Drive.Models;
using Microsoft.AspNetCore.Mvc;

namespace Drive.Services
{
    public interface IUserRepository
    {
        public void Create(User user);
    }
}