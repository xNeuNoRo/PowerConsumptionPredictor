namespace PowerConsumptionPredictor.WebApp.Models.Results;

public class MonthlyVariationItemViewModel
{
    public int MonthNumber { get; set; }
    public string VariationText { get; set; } = string.Empty;
    public double? VariationValue { get; set; }
}
