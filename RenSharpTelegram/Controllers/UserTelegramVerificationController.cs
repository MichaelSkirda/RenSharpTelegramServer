using BLL.Models;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RenSharpTelegram.Controllers
{
    public class UserTelegramVerificationController(IUserTelegramVerificationService service) : Controller
    {

        [HttpPost("user/telegram/verify")]
        public IActionResult Verify(string code, string telegramTag)
        {
            service.Verify(code, telegramTag);
            var result = new UserVerificationResult(telegramTag);
            return Ok(result);
        }

        [HttpGet("user/telegram/{guid}/verified")]
        public IActionResult HasVerified(string guid)
        {
            bool hasVerified = service.HasVerified(guid);
            return Ok(hasVerified);
        }

    }
}
