namespace BLL.Models
{
    public class UserVerificationResult
    {
        public string TelegramTag { get; set; }

        public UserVerificationResult(string telegramTag)
        {
            TelegramTag = telegramTag;
        }
    }
}
