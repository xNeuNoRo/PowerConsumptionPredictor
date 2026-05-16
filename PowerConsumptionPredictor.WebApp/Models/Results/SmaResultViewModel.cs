using PowerConsumptionPredictor.WebApp.Models.Results.Base;

namespace PowerConsumptionPredictor.WebApp.Models.Results;

public class SmaResultViewModel : BaseResultViewModel
{
    public double PredictedConsumption { get; set; }
    public override string PartialViewName => "_SmaResult";
}
