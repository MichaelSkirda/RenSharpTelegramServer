using BLL.Entities;
using BLL.Exceptions;
using BLL.Repositories;

namespace DAL.Repositories
{
    public class UserTelegramRepository(ApplicationContext db) : IUserTelegramRepository
    {

        public UserTelegram CreateUserTelegram()
        {
            var userTelegram = new UserTelegram()
            {
                Token = Guid.NewGuid(),
                Verified = false
            };

            db.Users.Add(userTelegram);
            db.SaveChanges();

            return userTelegram;
        }

        public UserTelegram GetUser(string guid)
        {
            UserTelegram? userTelegram = GetUserOrDefault(guid);

            if(userTelegram == null)
                throw new ResourceNotFoundException(nameof(userTelegram), guid);

            return userTelegram;
        }

        private UserTelegram? GetUserOrDefault(string guid)
        {
            return db.Users
                .FirstOrDefault(user => user.Token.ToString().Equals(guid, StringComparison.CurrentCultureIgnoreCase));
        }

        public bool HasVerified(string guid)
        {
            UserTelegram? userTelegram = GetUserOrDefault(guid);

            if (userTelegram == null)
                throw new ResourceNotFoundException(nameof(UserTelegram), guid);

            return userTelegram.Verified;
        }

        public void Verify(int userTelegramId, string telegramTag)
        {
            UserTelegram? userTelegram = db.Users.FirstOrDefault(x => x.Id == userTelegramId);

            if (userTelegram == null)
                throw new ResourceNotFoundException(nameof(UserTelegram), userTelegramId);

            userTelegram.VerifiedAt = DateTime.UtcNow;
            userTelegram.Verified = true;
            userTelegram.TelegramTag = telegramTag;

            db.SaveChanges();
        }
    }
}
