using MachineLearningMachine3000.Shared.Entities;

namespace MachineLearningMachine3000.Client.Services
{
    public interface IFactCaseForecastService
    {
        Task<List<FactCaseForecast>> GetFactCaseForecastsAsync();
        Task InsertFactCaseForecast(List<FactCaseForecast> factCaseForecasts);
        Task DeleteTableContent();
    }
}
