using MachineLearningMachine3000.Data;

namespace MachineLearningMachine3000.Services
{
    public interface IFactCaseForecastService
    {
        Task<List<FactCaseForecast>> GetFactCaseForecastsAsync();
        Task<List<FactCaseForecast>> InsertFactCaseForecast(List<FactCaseForecast> factCaseForecasts);
    }
}
