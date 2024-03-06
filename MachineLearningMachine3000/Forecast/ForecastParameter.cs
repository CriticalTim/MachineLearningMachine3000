﻿namespace MachineLearningMachine3000.Forecast
{
    public class ForecastParameter
    {
        public int windowSize { get; set; } = 7;
        public int seriesLength { get; set; } = 1183;
        public int trainSize { get; set; } = 1000;
        public int horizon { get; set; } = 38;

        public float confidenceLevel { get; set; } = 0.95f;
    }
}
