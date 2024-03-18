using MachineLearningMachine3000.Data;
using MachineLearningMachine3000.Shared.Entities;

namespace MachineLearningMachine3000.Services
{
    public interface IFactCaseService
    {
        Task<List<FactCase>> GetFactCasesAsync();
    }
}
