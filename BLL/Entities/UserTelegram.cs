namespace BLL.Entities
{
    public class UserTelegram
    {
        public int Id { get; set; }
        public Guid Token { get; set; }
        public string? TelegramTag { get; set; }

        public bool Verified { get; set; }
        public DateTime? VerifiedAt { get; set; }
    }
}
