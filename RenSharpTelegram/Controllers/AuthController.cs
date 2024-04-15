using BLL.Entities;
using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RenSharpTelegram.Controllers
{

    [ApiController]
    public class AuthController(IUserTelegramService service, ICodeService codeService) : ControllerBase
    {

        [HttpPost("user/telegram/register")]
        public IActionResult Register()
        {
            UserTelegram userTelegram = service.CreateUserTelegram();
            Code code = codeService.CreateCode(userTelegram.Id);

            if (code.Value == null)
                throw new Exception("Failed to create verification code. Pease try create account again.");

            var userVerification = new UserVerification(userTelegram.Token, code.Value);

            return Ok(userVerification);
        }
    }
}
