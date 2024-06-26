using Microsoft.EntityFrameworkCore;
using Drive.Models;

namespace Drive.Data;

public class DriveContext : DbContext
{
    public DriveContext(DbContextOptions<DriveContext> options) : base(options) {}

    public DbSet<User> Users { get; set; }

    public DbSet<Folder> Folders { get; set; }

    public DbSet<Filee> Files { get; set; }
}