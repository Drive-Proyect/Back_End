using Microsoft.AspNetCore.Mvc;
using Drive.Models;
using Drive.Services;
using System.Threading.Tasks;

namespace Drive.Controllers
{
    [ApiController]
    [Route("api/Users/Create")]
    public class UserCreateController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMailerSendRepository _mailerSendRepository;

        public UserCreateController(IUserRepository userRepository, IMailerSendRepository mailerSendRepository)
        {
            _userRepository = userRepository;
            _mailerSendRepository = mailerSendRepository;
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest("Los campos no pueden ser nulos");
            }
            try
            {
                await _userRepository.Create(user);
                // await _mailerSendRepository.SendMailAsync(user.Email, user.Username, user.Id, user.Password);
                return Ok("Te has registrado correctamente!");
            }
            catch (Exception e)
            {
                return StatusCode(500, $"Error al registrarse: {e.Message}");
            }
        }
    }
}