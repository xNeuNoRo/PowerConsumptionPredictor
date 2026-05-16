using Microsoft.AspNetCore.Mvc;
using PowerConsumptionPredictor.BusinessLogic.DTOs;
using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;
using PowerConsumptionPredictor.BusinessLogic.Interfaces;
using PowerConsumptionPredictor.WebApp.Mappers;
using PowerConsumptionPredictor.WebApp.Models.Inputs;

namespace PowerConsumptionPredictor.WebApp.Controllers;

public class HomeController : Controller
{
    private readonly IPredictorContext _predictorContext;

    public HomeController(IPredictorContext predictorContext)
    {
        _predictorContext = predictorContext;
    }

    [HttpGet]
    public IActionResult Index()
    {
        // Generamos un modelo nuevo que ya viene con los 12 meses inicializados en vacio
        var model = new HomeViewModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult Index(HomeViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            // Mapeamos los datos del viewmodel al dto de la req
            var requestDto = new PredictionRequestDto
            {
                History = model
                    .History.Select(h => new MonthlyConsumptionDto
                    {
                        Date = h.Date!.Value,
                        ConsumptionKwh = h.ConsumptionKwh!.Value,
                    })
                    .ToList(),
            };

            // Ejecutamos la logica de negocio y obtenemos el resultado en su formato DTO
            BasePredictionResponseDto response = _predictorContext.ExecutePrediction(requestDto);

            // Mapeamos el resultado del DTO al formato que entiende la vista (el ViewModel)
            model.Result = response.ToViewModel();
        }
        catch (ArgumentException ex)
        {
            // Agregamos el error esperado de validacion al ModelState para que se muestre en la vista
            ModelState.AddModelError(string.Empty, ex.Message);
        }
        catch (Exception)
        {
            // En caso de error inesperado, agregamos un mensaje generico al ModelState
            ModelState.AddModelError(
                string.Empty,
                "Ocurrio un error inesperado al procesar el calculo de consumo."
            );
        }

        return View(model);
    }
}
