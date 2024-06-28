using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Drive.Data;
using Drive.Models;

namespace Drive.Services;

public class UserRepository : IUserRepository
{
    private readonly DriveContext _context;

    public UserRepository(DriveContext context)
    {
        _context = context;
    }

    public void Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
}