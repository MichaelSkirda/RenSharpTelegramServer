using BLL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IUserTelegramService
    {
        UserTelegram CreateUserTelegram();
        UserTelegram GetUser(string guid);
        bool HasVerified(string guid);
        void Verify(int userTelegramId, string telegramTag);
    }
}