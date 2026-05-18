namespace PowerConsumptionPredictor.BusinessLogic.DTOs;

public class PredictionRequestDto
{
    /// <summary>
    /// Historial de consumo mensual del usuario, con al menos 12 meses de datos.
    /// </summary>
    public List<MonthlyConsumptionDto> History { get; set; } = new();
}
