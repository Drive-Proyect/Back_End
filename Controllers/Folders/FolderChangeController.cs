using Microsoft.AspNetCore.Mvc;
using Drive.Models;
using Drive.Services;
using System.Threading.Tasks;

namespace Drive.Controllers
{
    [ApiController]
    [Route("api/Folders/ChangeStatus")]
    public class FolderChangeController : ControllerBase
    {
        private readonly IFolderRepository _folderRepository;

        public FolderChangeController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        [HttpPut("{id}")]
        public IActionResult Change(int id)
        {
            _folderRepository.ChangeStatus(id);
            return Ok("La carpeta se ha movido a la papelera!");
        }
    }
}