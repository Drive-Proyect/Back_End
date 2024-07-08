namespace Drive.Services
{
    public interface IMailerSendRepository
    {
        Task SendMailAsync(string to, string userName, int id, string password);
    }
}