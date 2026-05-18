using PowerConsumptionPredictor.WebApp.Models.Results.Base;

namespace PowerConsumptionPredictor.WebApp.Models.Results;

public class TrendDetectionResultViewModel : BaseResultViewModel
{
    public int Increases { get; set; }
    public int Decreases { get; set; }
    public int StableMonths { get; set; }
    public string GeneralTrend { get; set; } = string.Empty;

    public override string PartialViewName => "_TrendDetectionResult";
}
