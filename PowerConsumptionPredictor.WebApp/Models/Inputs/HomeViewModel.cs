using System.ComponentModel.DataAnnotations;
using PowerConsumptionPredictor.WebApp.ViewModels.Results.Base;

namespace PowerConsumptionPredictor.WebApp.ViewModels.Inputs;

public class HomeViewModel
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
}
