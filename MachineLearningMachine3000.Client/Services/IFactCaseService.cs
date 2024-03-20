using MachineLearningMachine3000.Shared.Entities;

namespace MachineLearningMachine3000.Client.Services
{
    public interface IFactCaseService
    {
        Task<List<FactCase>> GetFactCasesAsync();
    }
}
