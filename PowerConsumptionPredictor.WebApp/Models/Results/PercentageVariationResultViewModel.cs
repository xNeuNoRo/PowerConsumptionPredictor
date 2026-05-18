using PowerConsumptionPredictor.WebApp.Models.Results.Base;

namespace PowerConsumptionPredictor.WebApp.Models.Results;

public class PercentageVariationResultViewModel : BaseResultViewModel
{
    public List<MonthlyVariationItemViewModel> MonthlyVariations { get; set; } = new();
    public double AveragePercentageVariation { get; set; }

    public override string PartialViewName => "_PercentageVariationResult";
}
