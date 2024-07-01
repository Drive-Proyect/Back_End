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

    public void Create(Folder folder)
    {
        folder.Status = "Active";
        _context.Folders.Add(folder);
        _context.SaveChanges();
    }

    public IEnumerable<Folder> GetFolders()
    {
        var folders = _context.Folders.Where(m => m.Status == "Active").ToList();

        if (folders.Any())
        {
            return folders;
        }
        throw new Exception("No se puede traer las carpetas");
    }

    public IEnumerable<Folder> Getpaperfolders()
    {
        var folderspaper = _context.Folders.Where(m => m.Status == "Inactive").ToList();

        if (folderspaper.Any())
        {
            return folderspaper;
        }
        throw new Exception("No se puede traer las carpetas");
    }

    public void RemovePaper(Folder folder, int id)
    {
        var folderRemove = _context.Folders.FirstOrDefault(m => m.Id == id);
        
        if (folderRemove != null)
        {
            folderRemove.Status = "Inactive";
            _context.Folders.Update(folderRemove);
            _context.SaveChanges();
        }
        else
        {
            throw new Exception("No se encontro la carpeta");
        }
    }
}