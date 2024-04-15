using BLL.Entities;
using BLL.Exceptions;
using BLL.Repositories;

namespace DAL.Repositories
{
    public class CodeRepository(ApplicationContext db) : ICodeRepository
    {
        private static readonly Random Random = new Random();
        private static object Locker = new object();

        public Code CreateCode(int userTelegramId)
        {
            lock (Locker)
            {
                return CreateCode(userTelegramId, attempsCount: 10);
            }
        }

        private Code CreateCode(int userTelegramId, int attempsCount)
        {
            if (attempsCount <= 0)
                throw new ArgumentException("Count of attemps must be mositive", nameof(attempsCount));

            for (int i = 0; i < attempsCount; i++)
            {
                string codeValue = Random.Next(0, 10000).ToString("0000");

                if (ActiveCodeNotExists(codeValue))
                    return CreateCode(userTelegramId, codeValue);
            }

            throw new Exception("Can not create code. Try again in few minutes.");
        }

        private Code CreateCode(int userTelegramId, string value)
        {
            Code code = new Code()
            {
                CreatedAt = DateTime.UtcNow,
                Value = value,
                UserTelegramId = userTelegramId
            };

            db.Codes.Add(code);
            db.SaveChanges();
            return code;
        }

        private bool ActiveCodeNotExists(string value)
            => !ActiveCodeExists(value);

        public bool ActiveCodeExists(string value)
        {
            return GetActiveCodes()
                .Where(code => code.Value == value)
                .Any();
        }

        private IQueryable<Code> GetActiveCodes()
        {
            DateTime notBefore = DateTime.UtcNow.AddMinutes(-15);
            return db.Codes
                .Where(code => code.CreatedAt > notBefore && code.UsedAt == null);
        }

        public Code ActivateCode(string value)
        {
            DateTime now = DateTime.UtcNow;

            List<Code> test = GetActiveCodes().ToList();

            Code? code = GetActiveCodes()
                .FirstOrDefault(code => code.Value == value);

            if (code == null)
                throw new VerificationCodeNotFoundException(value);

            code.UsedAt = now;
            db.SaveChanges();

            return code;
        }
    }
}
