using MachineLearningMachine3000.Data;
using MachineLearningMachine3000.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachineLearningMachine3000.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ForecastController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<FactCase>>> GetFactCasesControllerAsync()
        {
            var result = await _dataContext.FactCases.ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<FactCase>>> PostFactCasesControllerAsync(List<FactCase> factCases)
        {
            _dataContext.FactCases.AddRange(factCases);
            await _dataContext.SaveChangesAsync();
            return Ok(factCases);
        }






    }
}
