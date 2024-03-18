using MachineLearningMachine3000.Data;

namespace MachineLearningMachine3000.Services
{
    public interface IFactCaseForecastService
    {
        Task<List<FactCaseForecast>> GetFactCaseForecastsAsync();
        Task InsertONEFactCaseForecast(FactCaseForecast factCaseForecast);
        Task InsertFactCaseForecast(List<FactCaseForecast> factCaseForecasts);
        Task DeleteTableContent();
    }
}
