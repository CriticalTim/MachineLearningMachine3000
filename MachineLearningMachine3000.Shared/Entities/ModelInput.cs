﻿using Microsoft.ML.Data;
using System.IO;

namespace MachineLearningMachine3000.Shared.Entities
{
    public class ModelInput
    {
        [LoadColumn(0)]
        public DateTime Time { get; set; }

        [LoadColumn(1)]
        public float Value { get; set; }
    }
}
