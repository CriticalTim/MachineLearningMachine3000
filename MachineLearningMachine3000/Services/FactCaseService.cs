using MachineLearningMachine3000.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace MachineLearningMachine3000.Services
{
    public class FactCaseService : IFactCaseService
    {
        private readonly DataContext _dataContext;
        
        public FactCaseService(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<List<FactCase>> GetFactCasesAsync()
        {
           var result = await _dataContext.FactCases.ToListAsync();
            return result;
        }
    }
}
