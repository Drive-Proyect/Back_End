using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Drive.Data;
using Drive.Models;

namespace Drive.Services;

public class FolderRepository : IFolderRepository
{
    private readonly DriveContext _context;

    public FolderRepository(DriveContext context)
    {
        _context = context;
    }

    public void Create(Folder folder)
    {
        folder.Status = "Active";
        _context.Folders.Add(folder);
        _context.SaveChanges();
    }

    public void ChangeStatus(int id)
    {
        var folder = _context.Folders.FirstOrDefault(f => f.Id == id);

        if (folder != null)
        {
            folder.Status = "Inactive";
            _context.Update(folder);
            _context.SaveChanges();
        }
    }
}