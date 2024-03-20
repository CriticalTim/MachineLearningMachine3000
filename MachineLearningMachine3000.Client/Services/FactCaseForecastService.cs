using MachineLearningMachine3000.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace MachineLearningMachine3000.Client.Services
{
    public class FactCaseForecastService : IFactCaseForecastService
    {
        private HttpClient _client;

        public FactCaseForecastService(HttpClient context)
        {
            _client = context;
        }

        public async Task DeleteTableContent()
        {
            await _client.DeleteAsync("api/Forecast/truncate");
        }

        public async Task<List<FactCaseForecast>> GetFactCaseForecastsAsync()
        {
            var cases = await _client.GetFromJsonAsync<List<FactCaseForecast>>("api/Forecast");
            return cases;
        }

        public async Task InsertFactCaseForecast(List<FactCaseForecast> factCaseForecasts)
        {
            await _client.PostAsJsonAsync("api/Forecast", factCaseForecasts);
            
        }

        

    }
}
