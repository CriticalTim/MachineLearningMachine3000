using MachineLearningMachine3000.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.JSInterop;
using System.ComponentModel.DataAnnotations;
using Blazor.IndexedDB.Framework;

namespace MachineLearningMachine3000.Client.Data
{
    public class DataContextLocal(IJSRuntime jSRuntime, string name, int version) : IndexedDb(jSRuntime, name, version)
    {
        public IndexedSet<FactCaseForecast> FactCasesForecast { get; set; }

    }
}
