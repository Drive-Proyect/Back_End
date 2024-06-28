using Drive.Models;
using Microsoft.AspNetCore.Mvc;

namespace Drive.Services
{
    public interface IFolderRepository
    {
        public void Create(Folder folder);

        public void ChangeStatus(int id);
    }
}