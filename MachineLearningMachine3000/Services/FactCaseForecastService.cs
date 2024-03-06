﻿using MachineLearningMachine3000.Data;
using Microsoft.EntityFrameworkCore;

namespace MachineLearningMachine3000.Services
{
    public class FactCaseForecastService : IFactCaseForecastService
    {
        private readonly DataContext _context;

        public FactCaseForecastService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<FactCaseForecast>> GetFactCaseForecastsAsync()
        {
            var cases = await _context.FactCasesForecast.ToListAsync();
            return cases;
        }

        public async Task InsertFactCaseForecast(List<FactCaseForecast> factCaseForecasts)
        {
            //_context.FactCasesForecast.RemoveRange();
            //await _context.SaveChangesAsync();

            _context.FactCasesForecast.AddRange(factCaseForecasts);
            await _context.SaveChangesAsync();
;
        }

        public async Task InsertONEFactCaseForecast(FactCaseForecast factCaseForecast)
        {
            _context.FactCasesForecast.Add(factCaseForecast);
            await _context.SaveChangesAsync();
        }

    }
}
