using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Drive.Data;
using Drive.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Drive.Services;

public class FolderRepository : IFolderRepository
{
    private readonly DriveContext _context;

    public FolderRepository(DriveContext context)
    {
        _context = context;
    }

    public void Create(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public IEnumerable<Folder> GetFolders()
    {
        var folders = _context.Folders.Where(m=>m.Status == "Active").ToList();
        if (folders.Any())
        {
            return folders;
        }
        throw new Exception("No se puede traer las carpetas");
    }

    public IEnumerable<Folder> Getpaperfolders()
    {
        var folderspaper = _context.Folders.Where(m=>m.Status == "Inactive").ToList();
        if (folderspaper.Any())
        {
            return folderspaper;
        }
        throw new Exception("No se puede traer las carpetas");
    }

    public void removepaper(Folder folder, int id)
    {
        var folderremove = _context.Folders.FirstOrDefault(m => m.Id == id);
        if (folderremove != null)
        {
            folderremove.Status = "Inactive";
            _context.Folders.Update(folderremove);
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("No se encontro la carpeta");
        }
    }
}