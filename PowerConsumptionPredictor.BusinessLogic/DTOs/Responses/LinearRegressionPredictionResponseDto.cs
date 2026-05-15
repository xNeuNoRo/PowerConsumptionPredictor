using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;

namespace PowerConsumptionPredictor.BusinessLogic.DTOs.Responses;

public class LinearRegressionPredictionResponseDto : BasePredictionResponseDto
{
    /// <summary>
    /// Valor de consumo predicho para el proximo mes utilizando regresión lineal.
    /// </summary>
    public double PredictedConsumption { get; set; }
}
