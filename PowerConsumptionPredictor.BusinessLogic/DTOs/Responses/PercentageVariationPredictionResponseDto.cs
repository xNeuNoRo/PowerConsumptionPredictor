using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;

namespace PowerConsumptionPredictor.BusinessLogic.DTOs.Responses;

public class PercentageVariationPredictionResponseDto : BasePredictionResponseDto
{
    /// <summary>
    /// Valor de consumo predicho para el proximo mes utilizando el metodo de variacion porcentual.
    /// </summary>
    public double PredictedConsumption { get; set; }

    /// <summary>
    /// Valor de la variacion porcentual promedio calculada a partir de los 
    /// meses anteriores, que se utilizo para generar la prediccion.
    /// </summary>
    public double AveragePercentageVariation { get; set; }
}