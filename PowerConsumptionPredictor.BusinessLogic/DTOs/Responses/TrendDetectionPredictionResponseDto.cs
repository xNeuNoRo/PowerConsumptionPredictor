using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;

namespace PowerConsumptionPredictor.BusinessLogic.DTOs.Responses;

public class TrendDetectionPredictionResponseDto : BasePredictionResponseDto
{
    /// <summary>
    /// Numero de meses con aumento
    /// </summary>
    public int Increases { get; set; }

    /// <summary>
    /// Numero de meses con disminucion
    /// </summary>
    public int Decreases { get; set; }

    /// <summary>
    /// Numero de meses estables
    /// </summary>
    public int StableMonths { get; set; }

    /// <summary>
    /// Tendencia general
    /// </summary>
    public string GeneralTrend { get; set; } = string.Empty; // "Alcista", "Bajista", "Estable"
}
