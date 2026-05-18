using Microsoft.AspNetCore.Mvc;
using PowerConsumptionPredictor.BusinessLogic.Interfaces;
using PowerConsumptionPredictor.WebApp.Models.Inputs;

namespace PowerConsumptionPredictor.WebApp.Controllers;

public class ModeController : Controller
{
    private readonly IModePersistenceService _modeService;

    public ModeController(IModePersistenceService modeService)
    {
        _modeService = modeService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var currentMode = _modeService.GetCurrentMode();

        // Creamos el viewModel con el modo actual o default q ya viene seteado en el singleton
        var model = new ModeSelectionViewModel { SelectedMode = currentMode };

        return View(model);
    }

    [HttpPost]
    public IActionResult Index(ModeSelectionViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        _modeService.SetCurrentMode(model.SelectedMode);

        // Redirigimos al home para que empiece a usar el modo q selecciono
        return RedirectToAction("Index", "Home");
    }
}
