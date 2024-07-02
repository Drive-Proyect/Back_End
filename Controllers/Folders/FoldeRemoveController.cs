using Microsoft.AspNetCore.Mvc;
using Drive.Models;
using Drive.Services;
using System.Threading.Tasks;

namespace Drive.Controllers
{
    public class FoldeRemoveController : ControllerBase
    {
        private readonly IFolderRepository _folderRepository;


        public FoldeRemoveController(IFolderRepository userRepository)
        {
            _folderRepository = userRepository;
        }

        [HttpPut]
        [Route("api/folders/remove")]
        //..
        public IActionResult ChangeStatus([FromQuery] int id, [FromBody] Folder coupon)
        {
            try
            {
                _folderRepository.RemovePaper(coupon, id);
                return Ok("Cupon eliminado con exito");
            }
            catch (Exception e)
            {
                return StatusCode(403, new { e.Message });
            }
        }

    }
}
