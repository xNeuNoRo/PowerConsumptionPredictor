using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;

namespace PowerConsumptionPredictor.BusinessLogic.DTOs.Responses;

public class LinearRegressionPredictionResponseDto : BasePredictionResponseDto
{
    /// <summary>
    /// Valor de consumo predicho para el proximo mes utilizando regresión lineal.
    /// </summary>
    public double PredictedConsumption { get; set; }

    /// <summary>
    /// Pendiente de la línea de regresion, que indica la tendencia del consumo a lo largo del tiempo.
    /// </summary>
    public double Slope { get; set; }
}
