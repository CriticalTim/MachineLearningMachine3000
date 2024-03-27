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

        public async Task<List<ResultSet>> ServiceGetCalculation(ResultSetParameterWrapper wrapper)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Calculation/calculate", wrapper);
            return await result.Content.ReadFromJsonAsync<List<ResultSet>>();
        }

        public async Task<List<ResultSet>> ServiceGetRecalculation(ResultSetParameterForecastWrapper wrapper)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Calculation/recalculate", wrapper);
            return await result.Content.ReadFromJsonAsync<List<ResultSet>>();
        }
    }
}
