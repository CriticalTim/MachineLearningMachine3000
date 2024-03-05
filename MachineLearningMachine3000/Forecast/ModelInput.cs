namespace MachineLearningMachine3000.Forecast
{
    public class ModelInput
    {
        [LoadColumn(0)]
        public float Value { get; set; }

        [LoadColumn(1)]
        public DateTime Time { get; set; }
    }
}
