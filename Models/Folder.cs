using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Drive.Models;

public class Folder
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required DateTime CreationDate { get; set; }

    [Required]
    public required DateTime UpdateDate { get; set; }

    [Required]
    public required string LocationSpace { get; set; }

    public decimal? CapacityMemory { get; set; }

    [Required]
    public required string Status { get; set; }

    [Required]
    public required int UserId { get; set; }

    public User? User { get; set; }

    public int? FolderId { get; set; }

    Folder? ParentFolder { get; set; }
}