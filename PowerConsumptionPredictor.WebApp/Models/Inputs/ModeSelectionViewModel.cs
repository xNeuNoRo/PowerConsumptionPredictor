using System.ComponentModel.DataAnnotations;
using PowerConsumptionPredictor.BusinessLogic.Enums;

namespace PowerConsumptionPredictor.WebApp.Models.Inputs;

public class ModeSelectionViewModel
{
    [Required(ErrorMessage = "Debe seleccionar un modo de prediccion.")]
    public PredictionMode SelectedMode { get; set; }
}
