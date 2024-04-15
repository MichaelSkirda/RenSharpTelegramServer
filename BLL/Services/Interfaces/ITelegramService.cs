namespace BLL.Services.Interfaces
{
    public interface ITelegramService
    {
        void SendMessage(string guid, string message);
    }
}