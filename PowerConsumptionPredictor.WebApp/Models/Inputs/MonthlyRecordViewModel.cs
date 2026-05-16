using System.ComponentModel.DataAnnotations;

namespace PowerConsumptionPredictor.WebApp.Models.Inputs;

public class MonthlyRecordViewModel
{
    [Required(ErrorMessage = "La fecha es obligatoria.")]
    [DataType(DataType.Date)]
    public DateTime? Date { get; set; }

    [Required(ErrorMessage = "El consumo es obligatorio.")]
    [Range(0, double.MaxValue, ErrorMessage = "El consumo no puede ser negativo.")]
    public double? ConsumptionKwh { get; set; }
}
