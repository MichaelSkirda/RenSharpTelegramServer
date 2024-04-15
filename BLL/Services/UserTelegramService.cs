using BLL.Entities;
using BLL.Repositories;
using BLL.Services.Interfaces;

namespace BLL.Services
{
    public class UserTelegramService(IUserTelegramRepository repository) : IUserTelegramService
    {

        public UserTelegram CreateUserTelegram()
            => repository.CreateUserTelegram();

        public UserTelegram GetUser(string guid)
            => repository.GetUser(guid);

        public bool HasVerified(string guid)
            => repository.HasVerified(guid);

        public void Verify(int userTelegramId, string telegramTag)
            => repository.Verify(userTelegramId, telegramTag);
    }
}
