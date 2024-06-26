using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Drive.Models;

public class Filee
{
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    [Required]
    public required string FilesType { get; set; }

    [Required]
    public required DateTime CreationDate { get; set; }

    [Required]
    public required DateTime UpdateDate { get; set; }

    [Required]
    public required string DataSize { get; set; }

    [Required]
    public required string Status { get; set; }

    [Required]
    public required int UserId { get; set; }

    public User? User { get; set; }

    [Required]
    public required int FolderId { get; set; }

    public Folder? Folder { get; set; }
}