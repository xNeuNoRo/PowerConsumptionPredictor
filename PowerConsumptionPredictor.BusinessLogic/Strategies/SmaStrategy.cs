using PowerConsumptionPredictor.BusinessLogic.DTOs;
using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses;
using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;
using PowerConsumptionPredictor.BusinessLogic.Enums;
using PowerConsumptionPredictor.BusinessLogic.Interfaces;

namespace PowerConsumptionPredictor.BusinessLogic.Strategies;

public class SmaStrategy : IPredictionStrategy
{
    // Cumplimos con el contrato indicando qué modo somos
    public PredictionMode Mode => PredictionMode.SimpleMovingAverage;

    public BasePredictionResponseDto Calculate(PredictionRequestDto request)
    {
        // Validamos que tengamos al menos 3 meses de datos para hacer el calc
        if (request.History == null || request.History.Count < 3)
        {
            throw new InvalidOperationException(
                "Se requieren al menos 3 meses de historial para calcular el Promedio Movil Simple."
            );
        }

        // Ordenamos por fecha y tomamos los últimos 3 meses
        var lastThreeMonths = request.History.OrderBy(x => x.Date).TakeLast(3).ToList();

        // Sacamos el promedio de consumo de esos 3 meses para predecir el siguiente mes
        double predictedValue = lastThreeMonths.Average(x => x.ConsumptionKwh);

        // Interpretamos el resultado comparandolo con el ultimo mes conocido
        double lastKnownValue = lastThreeMonths[lastThreeMonths.Count - 1].ConsumptionKwh;
        string interpretation;

        if (predictedValue > lastKnownValue)
        {
            interpretation =
                "Se proyecta un aumento en el consumo basado en el promedio de los ultimos 3 meses.";
        }
        else if (predictedValue < lastKnownValue)
        {
            interpretation =
                "Se proyecta una disminucion en el consumo basado en el promedio de los ultimos 3 meses.";
        }
        else
        {
            interpretation = "Se espera que el consumo se mantenga estable respecto al ultimo mes.";
        }

        // Devolvemos la respuesta con el valor predicho y la interpretación
        return new SmaPredictionResponseDto
        {
            CalculationModeUsed = Mode,
            PredictedConsumption = predictedValue,
            InterpretationMessage = interpretation,
        };
    }
}
