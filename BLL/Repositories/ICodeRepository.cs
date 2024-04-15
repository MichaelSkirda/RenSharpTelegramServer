using BLL.Entities;

namespace BLL.Repositories
{
    public interface ICodeRepository
    {
        Code CreateCode(int userTelegramId);
        bool ActiveCodeExists(string value);
        Code ActivateCode(string code);
    }
}