namespace BLL.Services.Interfaces
{
    public interface IUserTelegramVerificationService
    {
        bool HasVerified(string guid);
        void Verify(string code, string telegramTag);
    }
}