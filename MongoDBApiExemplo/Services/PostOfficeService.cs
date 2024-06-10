using MongoDBApiExemplo.Models;
using Newtonsoft.Json;

namespace MongoDBApiExemplo.Services
{
    public class PostOfficeService
    {
        static readonly HttpClient client = new HttpClient();

        public static async Task<AddressDTO> GetAddres(string cep)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AddressDTO>(responseBody);
            }
            catch (HttpRequestException e)
            {
                throw;
            }
        }
    }
}
