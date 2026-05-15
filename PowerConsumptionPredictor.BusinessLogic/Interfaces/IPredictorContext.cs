using PowerConsumptionPredictor.BusinessLogic.DTOs;
using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;

namespace PowerConsumptionPredictor.BusinessLogic.Interfaces;

public interface IPredictorContext
{
    /// <summary>
    /// Ejecuta la prediccion utilizando la estrategia de prediccion actualmente seleccionada por el usuario.
    /// </summary>
    /// <param name="request">La solicitud de prediccion que contiene el historial de consumo</param>
    /// <returns>La respuesta con la prediccion de consumo</returns>
    BasePredictionResponseDto ExecutePrediction(PredictionRequestDto request);
}
