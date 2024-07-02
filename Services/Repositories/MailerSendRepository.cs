using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Drive.Services
{
    public class MailerSendRepository : IMailerSendRepository
    {
        private readonly HttpClient _httpClient;

        public MailerSendRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task SendMailAsync(string to, string userName, int id, string password)
        {
            try
            {
                var requestBody = new
                {
                    from = new
                    {
                        email = "user@trial-v69oxl5oo6rg785k.mlsender.net"
                    },
                    to = new[]
                    {
                        new
                        {
                            email = to
                        }
                    },
                    subject = "Te has registrado correctamente!",
                    personalization = new[]
                    {
                        new
                        {
                            email = to,
                            data = new
                            {
                                Id = id,
                                Email = to,
                                Password = password,
                                Username = userName
                            }
                        }
                    },
                    template_id = "0p7kx4x6zp249yjr"
                };

                var body = JsonSerializer.Serialize(requestBody);

                var request = new HttpRequestMessage(HttpMethod.Post, "https://api.mailersend.com/v1/email")
                {
                    Content = new StringContent(body, Encoding.UTF8, "application/json")
                };

                request.Headers.Add("Authorization", $"Bearer mlsn.2d2570bc49aa0df61b25fd63f4109ad01e0f709d2351176cd0a988a5ad6ea72e");

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Failed to send email: {response.ReasonPhrase}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}
