using PowerConsumptionPredictor.BusinessLogic.Enums;

namespace PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;

public abstract class BasePredictionResponseDto
{
    /// <summary>
    /// Indica el modo de calculo que se utilizo para generar la prediccion
    /// Por default, se asigna el modo de SMA.
    /// </summary>
    public PredictionMode CalculationModeUsed { get; set; } = PredictionMode.SimpleMovingAverage;

    /// <summary>
    /// Mensaje que interpreta el resultado de la prediccion, 
    /// por ejemplo, si se detecta una tendencia alcista o bajista, 
    /// o si se espera un aumento o disminucion en el consumo.
    /// </summary>
    public string InterpretationMessage { get; set; } = string.Empty;
}
