using Microsoft.AspNetCore.Mvc;
using Drive.Models;
using Drive.Services;
using System.Threading.Tasks;

namespace Drive.Controllers
{
    [ApiController]
    [Route("api/Folders/Create")]
    public class FolderCreateController : ControllerBase
    {
        private readonly IFolderRepository _folderRepository;

        public FolderCreateController(IFolderRepository folderRepository)
        {
            _folderRepository = folderRepository;
        }

        [HttpPost]
        public IActionResult CreateFolder(Folder folder)
        {
            if (folder == null)
            {
                return BadRequest("Los campos no pueden ser nulos");
            }

            try
            {
                _folderRepository.Create(folder);
                return Ok("La carpeta ha sido creada correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al crear la carpeta: {ex.Message}");
            }
        }
    }
}