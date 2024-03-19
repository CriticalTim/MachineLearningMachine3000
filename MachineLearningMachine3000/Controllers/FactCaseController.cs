using MachineLearningMachine3000.Data;
using MachineLearningMachine3000.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MachineLearningMachine3000.Services;

namespace MachineLearningMachine3000.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactCaseController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public FactCaseController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<FactCase>>> GetFactCasesControllerAsync()
        {
            var result = await _dataContext.FactCases.ToListAsync();
            return Ok(result);
        }

    }
}
