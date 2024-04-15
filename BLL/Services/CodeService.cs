using BLL.Entities;
using BLL.Repositories;
using BLL.Services.Interfaces;

namespace BLL.Services
{
    public class CodeService(ICodeRepository repository) : ICodeService
    {

        public Code CreateCode(int userTelegramId)
            => repository.CreateCode(userTelegramId);
    }
}
