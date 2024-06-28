namespace Drive.Services
{
    public interface IMailerSendRepository
    {
        Task SendMailAsync(string to, string user);
    }
}
