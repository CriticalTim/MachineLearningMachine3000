namespace MachineLearningMachine3000.Forecast
{
    public class Plotter
    {
        //public static void Plot(string datapath)
        //{
        //    var model = new PlotModel { Title = "Time Series" };
        //    var lineSeries = new LineSeries();

        //    using (var reader = new StreamReader(datapath))
        //    {
        //        while (!reader.EndOfStream)
        //        {
        //            var line = reader.ReadLine();
        //            if (line == null) continue;
        //            var values = line.Split(',');

        //            // Assuming the first column is time (x) and the second is your y-value
        //            double x = double.Parse(values[0]); // Convert time to a suitable numeric format if necessary
        //            double y = double.Parse(values[1]);

        //            lineSeries.Points.Add(new DataPoint(x, y));
        //        }
        //    }

        //    model.Series.Add(lineSeries);
        //    // Repeat the above steps for y1, y2, y3 with different LineSeries objects and add them to the model

        //    // Now, assign the model to your PlotView control
        //    //myPlotView.Model = model;
        //}

    }
}
