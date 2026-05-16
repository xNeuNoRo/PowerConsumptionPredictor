using PowerConsumptionPredictor.WebApp.ViewModels.Results.Base;

namespace PowerConsumptionPredictor.WebApp.ViewModels.Results;

public class SmaResultViewModel : BaseResultViewModel
{
    public double PredictedConsumption { get; set; }
    public override string PartialViewName => "_SmaResult";
}
