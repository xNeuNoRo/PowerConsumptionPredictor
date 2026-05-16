using PowerConsumptionPredictor.BusinessLogic.DTOs;
using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses;
using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;
using PowerConsumptionPredictor.BusinessLogic.Enums;
using PowerConsumptionPredictor.BusinessLogic.Interfaces;

namespace PowerConsumptionPredictor.BusinessLogic.Strategies;

public class TrendDetectionStrategy : IPredictionStrategy
{
    public PredictionMode Mode => PredictionMode.TrendDetection;

    public BasePredictionResponseDto Calculate(PredictionRequestDto request)
    {
        // Validamos que tengamos al menos 2 datos de historial para detectar una tendencia
        if (request.History == null || request.History.Count < 2)
        {
            throw new InvalidOperationException(
                "Se requieren al menos 2 meses de historial para detectar una tendencia."
            );
        }

        // Ordenamos el historial por fecha
        var sortedHistory = request.History.OrderBy(x => x.Date).ToList();

        int increases = 0;
        int decreases = 0;
        int stable = 0;

        // Iteramos desde el segundo mes comparando con el anterior
        for (int i = 1; i < sortedHistory.Count; i++)
        {
            double previous = sortedHistory[i - 1].ConsumptionKwh;
            double current = sortedHistory[i].ConsumptionKwh;

            if (current > previous)
            {
                increases++;
            }
            else if (current < previous)
            {
                decreases++;
            }
            else
            {
                stable++;
            }
        }

        string generalTrend;
        string interpretation;

        // Determinamos la tendencia general basandonos en la c
        // antidad de meses que aumentan, disminuyen o se mantienen estables
        if (increases > decreases && increases > stable)
        {
            generalTrend = "Alcista";
            interpretation =
                "La mayoria de los meses muestran un aumento, indicando una tendencia general alcista en el consumo.";
        }
        else if (decreases > increases && decreases > stable)
        {
            generalTrend = "Bajista";
            interpretation =
                "La mayoria de los meses muestran una disminucion, indicando una tendencia general bajista en el consumo.";
        }
        else if (stable > increases && stable > decreases)
        {
            generalTrend = "Estable";
            interpretation =
                "La mayoria de los meses no muestran variacion, indicando un consumo altamente estable.";
        }
        else
        {
            // En caso de empate o distribucion mixta, lo consideramos como tendencia mixta
            generalTrend = "Mixta";
            interpretation =
                "El comportamiento es fluctuante y no hay una tendencia mayoritaria clara entre los aumentos, disminuciones o estabilidad.";
        }

        return new TrendDetectionPredictionResponseDto
        {
            CalculationModeUsed = Mode,
            Increases = increases,
            Decreases = decreases,
            StableMonths = stable,
            GeneralTrend = generalTrend,
            InterpretationMessage = interpretation,
        };
    }
}
