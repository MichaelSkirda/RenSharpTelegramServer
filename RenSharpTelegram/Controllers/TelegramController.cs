using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RenSharpTelegram.Controllers
{
    public class TelegramController(ITelegramService service) : Controller
    {

        [HttpPost("telegram/sendMessage")]
        public IActionResult SendMessage(string guid, string message)
        {
            service.SendMessage(guid, message);
            return Ok();
        }

    }
}
