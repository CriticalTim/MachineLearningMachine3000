using MachineLearningMachine3000.Shared.Entities;

namespace MachineLearningMachine3000.Client.Services
{
    public interface ICalculationService
    {
        Task<ResultSetParameterWrapper?> ServiceGetCalculation(MultipartFormDataContent wrapper);
        Task<ResultSetParameterWrapper?> ServiceGetRecalculation(MultipartFormDataContent wrapper);

    }
}
