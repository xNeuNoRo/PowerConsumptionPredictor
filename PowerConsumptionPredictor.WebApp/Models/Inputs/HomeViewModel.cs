using System.ComponentModel.DataAnnotations;
using PowerConsumptionPredictor.WebApp.Models.Results.Base;

namespace PowerConsumptionPredictor.WebApp.Models.Inputs;

public class HomeViewModel : IValidatableObject
{
    [Required(ErrorMessage = "El historial de consumo es obligatorio.")]
    [MinLength(12, ErrorMessage = "El sistema requiere exactamente 12 registros historicos.")]
    [MaxLength(12, ErrorMessage = "El sistema solo permite procesar 12 registros historicos.")]
    public List<MonthlyRecordViewModel> History { get; set; } = new();

    public BaseResultViewModel? Result { get; set; }

    public HomeViewModel()
    {
        // Inicializamos la lista con 12 registros vacíos para que el formulario se renderice correctamente.
        for (int i = 0; i < 12; i++)
        {
            History.Add(new MonthlyRecordViewModel());
        }
    }

    // Validamos que no haya meses duplicados en el historial
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        // Filtramos los registros con fecha
        var validRecords = History.Where(h => h.Date.HasValue).ToList();

        var duplicates = validRecords
            .GroupBy(h => new { h.Date!.Value.Month, h.Date!.Value.Year }) // Agrupamos por mes y año
            .Where(g => g.Count() > 1) // Si al agrupar hay mas de 1, obviamente es pq hay dup
            .Select(g => $"{g.Key.Month}/{g.Key.Year}")
            .ToList();

        if (duplicates.Any())
        {
            yield return new ValidationResult(
                $"No se permiten meses duplicados en el historial: {string.Join(", ", duplicates)}."
            );
        }
    }
}
