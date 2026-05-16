using PowerConsumptionPredictor.BusinessLogic.Enums;

namespace PowerConsumptionPredictor.WebApp.Models.Results.Base;

public abstract class BaseResultViewModel
{
    public PredictionMode CalculationModeUsed { get; set; }
    public string InterpretationMessage { get; set; } = string.Empty;
    public abstract string PartialViewName { get; }
}
