using PowerConsumptionPredictor.WebApp.ViewModels.Results.Base;

namespace PowerConsumptionPredictor.WebApp.ViewModels.Results;

public class LinearRegressionResultViewModel : BaseResultViewModel
{
    public double PredictedConsumption { get; set; }
    public double Slope { get; set; }
    public override string PartialViewName => "_LinearRegressionResult";
}
