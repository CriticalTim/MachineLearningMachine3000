using MachineLearningMachine3000.Shared.Entities;

namespace MachineLearningMachine3000.Client.Services
{
    public interface ICalculationService
    {
        Task<List<ResultSet>> ServiceGetCalculation();
        Task<List<ResultSet>> ServiceGetRecalculation();

    }
}
