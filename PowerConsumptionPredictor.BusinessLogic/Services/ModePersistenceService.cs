using PowerConsumptionPredictor.BusinessLogic.Enums;
using PowerConsumptionPredictor.BusinessLogic.Interfaces;

namespace PowerConsumptionPredictor.BusinessLogic.Services;

public class ModePersistenceService : IModePersistenceService
{
    /// <summary>
    /// Almacena el modo de prediccion actualmente seleccionado.
    /// Por default, lo establecemos en SMA.
    /// </summary>
    private PredictionMode _currentMode = PredictionMode.SimpleMovingAverage;

    /// <summary>
    /// Obtiene el modo de prediccion actualmente seleccionado.
    /// </summary>
    /// <returns>El modo de prediccion actual</returns>
    public PredictionMode GetCurrentMode()
    {
        return _currentMode;
    }

    /// <summary>
    /// Establece el modo de prediccion actualmente seleccionado.
    /// </summary>
    /// <param name="mode">El modo de prediccion a establecer</param>
    public void SetCurrentMode(PredictionMode mode)
    {
        _currentMode = mode;
    }
}
