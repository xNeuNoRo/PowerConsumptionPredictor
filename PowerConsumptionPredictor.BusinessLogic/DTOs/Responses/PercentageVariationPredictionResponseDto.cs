using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;

namespace PowerConsumptionPredictor.BusinessLogic.DTOs.Responses;

public class PercentageVariationPredictionResponseDto : BasePredictionResponseDto
{
    /// <summary>
    /// Lista de variaciones porcentuales mes a mes calculadas a partir del historial
    /// </summary>
    public List<MonthlyVariationDto> MonthlyVariations { get; set; } = new();

    /// <summary>
    /// Valor de la variacion porcentual promedio calculada a partir de los
    /// meses anteriores, que se utilizo para generar la prediccion.
    /// </summary>
    public double AveragePercentageVariation { get; set; }
}
