using MachineLearningMachine3000.Shared.Entities;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace MachineLearningMachine3000.Client.Services
{
    public class CalculationService : ICalculationService
    {
        private HttpClient _httpClient;

        public CalculationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultSet>?> ServiceGetCalculation(MultipartFormDataContent content)
        {
            var response = await _httpClient.PostAsync("api/Calculation/calculate", content);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<List<ResultSet>>();
                return responseData;
            }
            return null;
        }

        public async Task<List<ResultSet>?> ServiceGetRecalculation(MultipartFormDataContent content)
        {
            var response = await _httpClient.PostAsync($"api/Calculation/recalculate", content);
            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<List<ResultSet>>();
                return responseData;
            }
            return null;
        }
    }
}
