using Drive.Models;
using Microsoft.AspNetCore.Mvc;

namespace Drive.Services
{
    public interface IFolderRepository
    {

        IEnumerable<Folder> GetFolders(int id);
        void removepaper (Folder folder,int id);
        IEnumerable<Folder> Getpaperfolders(int id);
        public void Create(Folder folder);
    }
}