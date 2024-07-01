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
        [Route("api/foolders/remove")]
        //..
            public IActionResult ChangeStatus([FromQuery] int id, [FromBody] Folder coupon)
            {
                try
                {
                    _folderRepository.removepaper(coupon, id);
                    return Ok("Cupon eliminado con exito");
                }
                catch (Exception e)
                {
                    return StatusCode(403, new { e.Message });
                }
            }

        }
    }
