namespace PowerConsumptionPredictor.BusinessLogic.DTOs.Responses;

/// <summary>
/// DTO auxiliar para la respuesta de la prediccion basada en variacion porcentual.
/// </summary>
public class MonthlyVariationDto
{
    /// <summary>
    /// Numero del mes en la secuencia historica (1 para el primer mes, 2 para el segundo, etc.)
    /// </summary>
    public int MonthNumber { get; set; }

    /// <summary>
    /// Texto que representa la variacion porcentual del mes.
    /// Puede ser algo como "+5.2%", "-3.1%" o "n/a" si no es calculable.
    /// </summary>
    public string VariationText { get; set; } = string.Empty;

    /// <summary>
    /// Valor numerico de la variacion porcentual del mes.
    /// Es nullable para casos donde no sea calculable o se quiera representar como "n/a".
    /// </summary>
    public double? VariationValue { get; set; }
}
