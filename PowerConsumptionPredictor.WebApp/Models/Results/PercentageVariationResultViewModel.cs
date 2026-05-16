using PowerConsumptionPredictor.WebApp.ViewModels.Results.Base;

namespace PowerConsumptionPredictor.WebApp.ViewModels.Results;

public class PercentageVariationResultViewModel : BaseResultViewModel
{
    public List<MonthlyVariationItemViewModel> MonthlyVariations { get; set; } = new();
    public double AveragePercentageVariation { get; set; }

    public override string PartialViewName => "_PercentageVariationResult";
}
