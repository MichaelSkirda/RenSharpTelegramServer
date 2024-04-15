using BLL.Entities;
using BLL.Repositories;
using BLL.Services.Interfaces;

namespace BLL.Services
{
    public class UserTelegramVerificationService(ICodeRepository codeRepository, IUserTelegramService userTelegramService)
        : IUserTelegramVerificationService
    {
        public bool HasVerified(string guid)
            => userTelegramService.HasVerified(guid);

        public void Verify(string codeValue, string telegramTag)
        {
            Code code = codeRepository.ActivateCode(codeValue);
            userTelegramService.Verify(code.UserTelegramId, telegramTag);
        }

    }
}
