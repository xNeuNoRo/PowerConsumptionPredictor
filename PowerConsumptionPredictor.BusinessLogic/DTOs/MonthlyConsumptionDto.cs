namespace PowerConsumptionPredictor.BusinessLogic.DTOs;

public class MonthlyConsumptionDto
{
    /// <summary>
    /// Fecha del consumo
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Consumo en kWh
    /// </summary>
    public double ConsumptionKwh { get; set; }
}
