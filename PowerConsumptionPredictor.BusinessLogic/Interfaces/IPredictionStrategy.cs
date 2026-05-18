using PowerConsumptionPredictor.BusinessLogic.DTOs;
using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;
using PowerConsumptionPredictor.BusinessLogic.Enums;

namespace PowerConsumptionPredictor.BusinessLogic.Interfaces;

public interface IPredictionStrategy
{
    /// <summary>
    /// Indica el modo de prediccion que implementa esta estrategia, para que el controlador pueda seleccionarla correctamente.
    /// </summary>
    PredictionMode Mode { get; }

    /// <summary>
    /// Calcula la prediccion de consumo para el proximo mes utilizando el metodo correspondiente a esta estrategia,
    /// a partir del historial de consumo proporcionado en la solicitud.
    /// </summary>
    /// <param name="request">La solicitud de prediccion que contiene el historial de consumo</param>
    /// <returns>La respuesta con la prediccion de consumo</returns>
    BasePredictionResponseDto Calculate(PredictionRequestDto request);
}
