using MachineLearningMachine3000.Data;
using MachineLearningMachine3000.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML;

namespace MachineLearningMachine3000.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : ControllerBase
    {

        private readonly DataContextLocal _dataContext;

        public ForecastController(DataContextLocal dataContextLocal)
        {
            _dataContext = dataContextLocal;
        }

        [HttpGet]
        public async Task<ActionResult<List<FactCaseForecast>>> GetForecastAsync()
        {
            var result = await _dataContext.FactCasesForecast.ToListAsync();
            return Ok(result);
        }

        [HttpDelete("truncate")]
        public async Task<ActionResult> TruncateTableAsync()
        {
            try
            {
                await _dataContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE [MachineLearningMachine3000].[DP_FC_156].[Fact_Cases_Forecast]");
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> InsertForecastAsync(List<FactCaseForecast> factCaseForecasts)
        {
            try
            {
                _dataContext.FactCasesForecast.AddRange(factCaseForecasts);
                await _dataContext.SaveChangesAsync();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);  
            }
            
        }

    }
}
