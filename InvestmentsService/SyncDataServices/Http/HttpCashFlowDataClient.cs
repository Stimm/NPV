using InvestmentsService.Dtos;
using System.Text.Json;
using System.Text;

namespace InvestmentsService.SyncDataServices.Http
{
    public class HttpCashFlowDataClient : IInvestmentsDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCashFlowDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task sendInvestmentsToCashFlow(ReadInvestmentDto investment)
        {
            var httpContent = new StringContent(
              JsonSerializer.Serialize(investment),
              Encoding.UTF8,
              "application/json"
               );
            var uri = _configuration["CashFlowService"];
            var responce = await _httpClient.PostAsync($"{_configuration["CashFlowService"]}/api/c/Investment", httpContent);

            if (responce.IsSuccessStatusCode)
            {
                Console.WriteLine("Sync Post to CashFlow service was ok");
            }
            else
            {
                Console.WriteLine("Sync Post to CashFlow service was not ok");
            }
        }
    }
}
