using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Drive.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string LastName { get; set; }

    [Required]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
}