using PowerConsumptionPredictor.BusinessLogic.DTOs;
using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses;
using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;
using PowerConsumptionPredictor.BusinessLogic.Enums;
using PowerConsumptionPredictor.BusinessLogic.Interfaces;

namespace PowerConsumptionPredictor.BusinessLogic.Strategies;

public class PercentageVariationStrategy : IPredictionStrategy
{
    public PredictionMode Mode => PredictionMode.PercentageVariation;

    public BasePredictionResponseDto Calculate(PredictionRequestDto request)
    {
        // P.Denfesiva, prefiero validar nuevamente aqui tambien por si acaso,
        // ya que es buena practica por si otro dev hiciera un desastre y llamara a esta
        // estrategia directamente sin pasar por el contexto o algo por el estilo.
        // --------------------------------------------------------------
        // Validamos que tengamos al menos 2 datos de historial para calcular la variacion porcentual
        if (request.History == null || request.History.Count < 2)
        {
            throw new InvalidOperationException(
                "Se requieren al menos 2 datos de historial para calcular la variacion porcentual."
            );
        }

        // Ordenamos el historial por fecha para asegurarnos
        // de que estamos calculando las variaciones en el orden correcto
        var sortedHistory = request.History.OrderBy(h => h.Date).ToList();
        var variationsList = new List<MonthlyVariationDto>();

        // Inicializamos variables para calcular el promedio de variaciones
        double sumVariations = 0;
        int validVariationsCount = 0;

        // Como el Mes 1 no tiene mes anterior, le asignamos "n/a"
        variationsList.Add(
            new MonthlyVariationDto
            {
                MonthNumber = 1,
                VariationText = "n/a",
                VariationValue = null,
            }
        );

        // Recorremos desde el mes 2 (idx 1) en adelante
        for (int i = 1; i < sortedHistory.Count; i++)
        {
            double previousConsumption = sortedHistory[i - 1].ConsumptionKwh;
            double currentConsumption = sortedHistory[i].ConsumptionKwh;
            int currentMonthNumber = i + 1;

            // Si el consumo anterior es 0, la division no seria calculable, asi que lo marcamos como "n/a"
            if (previousConsumption == 0)
            {
                variationsList.Add(
                    new MonthlyVariationDto
                    {
                        MonthNumber = currentMonthNumber,
                        VariationText = "No calculable",
                        VariationValue = null,
                    }
                );
            }
            else
            {
                // Aplicamos la formula de variacion porcentual
                double variation =
                    (currentConsumption - previousConsumption) / previousConsumption * 100;

                variationsList.Add(
                    new MonthlyVariationDto
                    {
                        MonthNumber = currentMonthNumber,
                        // Lo mostramos mas bonito redondeado para la UI
                        VariationText = $"{Math.Round(variation, 2)}%",
                        VariationValue = variation,
                    }
                );

                sumVariations += variation;
                validVariationsCount++;
            }
        }

        // Calculamos el promedio excluyendo los meses "No calculables"
        double averageVariation =
            validVariationsCount > 0 ? sumVariations / validVariationsCount : 0;

        // Interpretamos el resultado basandonos en la variacion porcentual promedio
        string interpretation;
        if (averageVariation > 1)
        {
            interpretation = "El consumo general esta aumentando.";
        }
        else if (averageVariation < -1)
        {
            interpretation = "El consumo general esta disminuyendo.";
        }
        else
        {
            interpretation = "El consumo general permanece estable.";
        }

        return new PercentageVariationPredictionResponseDto
        {
            CalculationModeUsed = Mode,
            MonthlyVariations = variationsList,
            AveragePercentageVariation = averageVariation,
            InterpretationMessage = interpretation,
        };
    }
}
