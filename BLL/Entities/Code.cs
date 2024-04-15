namespace BLL.Entities
{
    public class Code
    {
        public int Id { get; set; }
        public string? Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UsedAt { get; set; }

        public int UserTelegramId { get; set; }
        public UserTelegram? UserTelegram { get; set; }
    }
}
