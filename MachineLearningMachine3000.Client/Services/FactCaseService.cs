using MachineLearningMachine3000.Shared.Entities;
using System.Net.Http;
using Microsoft.EntityFrameworkCore;
using static System.Net.WebRequestMethods;
using System.Net.Http.Json;

namespace MachineLearningMachine3000.Client.Services
{
    public class FactCaseService : IFactCaseService
    {
        private HttpClient _client;
        
        public FactCaseService(HttpClient context)
        {
            _client = context;
        }
        public async Task<List<FactCase>> GetFactCasesAsync()
        {
           var result = await _client.GetFromJsonAsync<List<FactCase>>("api/FactCase");
          
            return result;
        }
    }
}
