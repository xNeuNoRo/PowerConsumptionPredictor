namespace PowerConsumptionPredictor.WebApp.Models.Results.Base;

public abstract class BaseResultViewModel
{
    public string CalculationModeUsed { get; set; } = string.Empty;
    public string InterpretationMessage { get; set; } = string.Empty;
    public abstract string PartialViewName { get; }
}
