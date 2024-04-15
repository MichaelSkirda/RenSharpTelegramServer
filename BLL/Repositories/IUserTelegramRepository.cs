using BLL.Entities;

namespace BLL.Repositories
{
    public interface IUserTelegramRepository
    {
        UserTelegram CreateUserTelegram();
        UserTelegram GetUser(string guid);
        bool HasVerified(string guid);
        void Verify(int userTelegramId, string telegramTag);
    }
}