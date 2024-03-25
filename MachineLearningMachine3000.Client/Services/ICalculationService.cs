using MachineLearningMachine3000.Shared.Entities;

namespace MachineLearningMachine3000.Client.Services
{
    public interface ICalculationService
    {
        Task<ResultSetParameterWrapper> ServiceGetCalculation(ResultSetParameterWrapper wrapper);
        Task<ResultSetParameterWrapper> ServiceGetRecalculation(ResultSetParameterWrapper wrapper);

    }
}
