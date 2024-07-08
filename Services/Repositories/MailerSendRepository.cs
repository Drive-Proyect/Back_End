using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System;

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

                request.Headers.Add("Authorization", "Bearer mlsn.62af81129fc3e2c79d3f5304c06d9fa3781d06b478f80afdbce3d6c23e0e2aec");

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Failed to send email: {response.ReasonPhrase}. Details: {responseContent}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
                throw;
            }
        }
    }
}
