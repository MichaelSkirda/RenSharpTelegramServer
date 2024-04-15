using BLL.Entities;

namespace BLL.Services.Interfaces
{
    public interface ICodeService
    {
        Code CreateCode(int userTelegramId);
    }
}