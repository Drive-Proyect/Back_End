using Drive.Models;
using Microsoft.AspNetCore.Mvc;

namespace Drive.Services
{
    public interface IFolderRepository
    {
        IEnumerable<Folder> GetFolders();
        void removepaper (Folder folder,int id);
        IEnumerable<Folder> Getpaperfolders();
    }
}