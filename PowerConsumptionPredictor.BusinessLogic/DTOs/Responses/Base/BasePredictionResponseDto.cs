namespace PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;

public abstract class BasePredictionResponseDto
{
    /// <summary>
    /// Indica el modo de calculo que se utilizo para generar la prediccion
    /// </summary>
    public string CalculationModeUsed { get; set; } = string.Empty;

    /// <summary>
    /// Mensaje que interpreta el resultado de la prediccion, 
    /// por ejemplo, si se detecta una tendencia alcista o bajista, 
    /// o si se espera un aumento o disminucion en el consumo.
    /// </summary>
    public string InterpretationMessage { get; set; } = string.Empty;
}
