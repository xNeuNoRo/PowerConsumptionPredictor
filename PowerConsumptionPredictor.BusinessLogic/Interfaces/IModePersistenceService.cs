using PowerConsumptionPredictor.BusinessLogic.Enums;

namespace PowerConsumptionPredictor.BusinessLogic.Interfaces;

public interface IModePersistenceService
{
    /// <summary>
    /// Obtiene el modo de prediccion actualmente seleccionado por el usuario.
    /// </summary>
    /// <returns>El modo de prediccion actual</returns>
    PredictionMode GetCurrentMode();

    /// <summary>
    /// Establece el modo de prediccion seleccionado por el usuario para que se mantenga entre sesiones.
    /// </summary>
    /// <param name="mode">El modo de prediccion a establecer</param>
    void SetCurrentMode(PredictionMode mode);
}
