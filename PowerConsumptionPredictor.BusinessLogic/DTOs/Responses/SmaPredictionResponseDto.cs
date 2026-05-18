using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;

namespace PowerConsumptionPredictor.BusinessLogic.DTOs.Responses;

public class SmaPredictionResponseDto : BasePredictionResponseDto
{
    /// <summary>
    /// Valor de consumo predicho para el proximo mes utilizando el metodo de promedio movil simple (SMA).
    /// </summary>
    public double PredictedConsumption { get; set; }
}
