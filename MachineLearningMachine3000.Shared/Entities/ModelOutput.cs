namespace MachineLearningMachine3000.Shared.Entities
{
    public class ModelOutput
    {
        public float[] ForecastedValues { get; set; }

        public float[] ConfidenceIntervalLowerBounds { get; set; }
        public float[] ConfidenceIntervalUpperBounds { get; set; }
    }
}
