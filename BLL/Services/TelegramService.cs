using BLL.Entities;
using BLL.Services.Interfaces;

namespace BLL.Services
{
    public class TelegramService(IUserTelegramService userTelegramService) : ITelegramService
    {

        public void SendMessage(string guid, string message)
        {
            UserTelegram userTelegram = userTelegramService.GetUser(guid);
        }

    }
}
