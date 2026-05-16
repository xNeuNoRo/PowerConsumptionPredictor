using PowerConsumptionPredictor.BusinessLogic.DTOs;
using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;
using PowerConsumptionPredictor.BusinessLogic.Interfaces;

namespace PowerConsumptionPredictor.BusinessLogic.Services;

public class PredictorContext : IPredictorContext
{
    private readonly IEnumerable<IPredictionStrategy> _strategies;
    private readonly IModePersistenceService _modePersistenceService;

    /// <summary>
    /// Constructor del contexto de prediccion. Recibe todas las estrategias d
    /// e prediccion disponibles y el servicio de persistencia de modo.
    /// </summary>
    /// <param name="strategies">La colección de estrategias de prediccion disponibles</param>
    /// <param name="modePersistenceService">El servicio de persistencia de modo</param>
    public PredictorContext(
        IEnumerable<IPredictionStrategy> strategies,
        IModePersistenceService modePersistenceService
    )
    {
        _strategies = strategies;
        _modePersistenceService = modePersistenceService;
    }

    /// <summary>
    /// Ejecuta la prediccion utilizando la estrategia de prediccion actualmente seleccionada por el usuario.
    /// </summary>
    /// <param name="request">La solicitud de prediccion</param>
    /// <returns>La respuesta de prediccion</returns>
    /// <exception cref="InvalidOperationException">Se lanza cuando no se encuentra una estrategia para el modo seleccionado</exception>
    public BasePredictionResponseDto ExecutePrediction(PredictionRequestDto request)
    {
        var currentMode = _modePersistenceService.GetCurrentMode();

        var strategy = _strategies.FirstOrDefault(s => s.Mode == currentMode);

        if (strategy == null)
        {
            throw new InvalidOperationException(
                $"El modo de prediccion '{currentMode}' no existe en el sistema."
            );
        }

        return strategy.Calculate(request);
    }
}
