using Microsoft.AspNetCore.Mvc;
using Drive.Models;
using Drive.Services;
using System.Threading.Tasks;

namespace Drive.Controllers
{
    public class FoldersController : ControllerBase
    {
        private readonly IFolderRepository _folderRepository;
        

        public FoldersController(IFolderRepository userRepository)
        {
            _folderRepository = userRepository;
        }

        [HttpGet]
        [Route("api/folders")]
         public IActionResult GetFolders()
        {
            try
            {
                var folders = _folderRepository.GetFolders();
                if (folders.Count() <1)
                {
                    return BadRequest("No existen carpetas");
                }
                else
                {
                    return Ok(folders);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(203, new { message = ex.Message });
            }
        }
        [HttpGet]
        [Route("api/paperfolders")]
        public IActionResult GetPaperFolders()
        {
         
            try
            {
                var foldersremove = _folderRepository.Getpaperfolders();
                if (foldersremove.Count() <1)
                {
                    return BadRequest("No existen carpetas");
                }
                else
                {
                    return Ok(foldersremove);
                }

            }
            catch (Exception ex)
            {
                return StatusCode(203, new { message = ex.Message });
            }   
        }
    }
}
