using MachineLearningMachine3000.Data;

namespace MachineLearningMachine3000.Services
{
    public interface IFactCaseService
    {
        Task<List<FactCase>> GetFactCasesAsync();
    }
}
