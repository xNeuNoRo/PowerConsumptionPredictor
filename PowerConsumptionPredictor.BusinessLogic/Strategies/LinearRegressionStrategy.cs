using PowerConsumptionPredictor.BusinessLogic.DTOs;
using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses;
using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;
using PowerConsumptionPredictor.BusinessLogic.Enums;
using PowerConsumptionPredictor.BusinessLogic.Interfaces;

namespace PowerConsumptionPredictor.BusinessLogic.Strategies;

public class LinearRegressionStrategy : IPredictionStrategy
{
    public PredictionMode Mode => PredictionMode.LinearRegression;

    public BasePredictionResponseDto Calculate(PredictionRequestDto request)
    {
        // P.Denfesiva, prefiero validar nuevamente aqui tambien por si acaso, 
        // ya que es buena practica por si otro dev hiciera un desastre y llamara a esta 
        // estrategia directamente sin pasar por el contexto o algo por el estilo.
        // --------------------------------------------------------------
        // Validamos que tengamos al menos 2 meses de datos para trazar una regresion lineal
        if (request.History == null || request.History.Count < 2)
        {
            throw new InvalidOperationException(
                "Se requieren al menos 2 meses de datos para trazar una regresion lineal."
            );
        }

        // Ordenamos cronologicamente y proyectamos a un objeto anonimo con X e Y usando LINQ
        // X = el indice de tiempo (1, 2, 3...)
        // Y = el consumo en kWh
        var data = request
            .History.OrderBy(h => h.Date)
            .Select((h, index) => new { X = index + 1.0, Y = h.ConsumptionKwh })
            .ToList();

        int n = data.Count;

        // Calculamos las sumatorias necesarias para la formula de regresion lineal
        double sumX = data.Sum(d => d.X);
        double sumY = data.Sum(d => d.Y);
        double sumXY = data.Sum(d => d.X * d.Y);
        double sumX2 = data.Sum(d => Math.Pow(d.X, 2));

        // Calculamos la pendiente (m)
        double numerator = sumXY - (sumX * sumY / n);
        double denominator = sumX2 - (Math.Pow(sumX, 2) / n);

        // Pendiente (m)
        // Si el divisor es 0, obviamente se asume que la pendiente es 0
        double m = denominator == 0 ? 0 : numerator / denominator;

        // Intercepto (b)
        // Para calcular el intercepto, necesitamos el promedio de la sumatoria de X e Y
        double avgX = sumX / n;
        double avgY = sumY / n;
        double b = avgY - (m * avgX);

        // Predecimos el consumo para el mes n + 1  (el mes 13 por asi decirlo)
        double nextMonthX = n + 1;
        double predictedConsumption = (m * nextMonthX) + b;

        // Determinamos la tendencia basandonos en la pendiente (m)
        string interpretation;
        if (m > 0)
        {
            interpretation = "Tendencia alcista. Se espera que el consumo general aumente.";
        }
        else if (m < 0)
        {
            interpretation = "Tendencia bajista. Se espera que el consumo general disminuya.";
        }
        else
        {
            interpretation =
                "Tendencia estable. Se espera que el consumo se mantenga sin variaciones significativas.";
        }

        return new LinearRegressionPredictionResponseDto
        {
            CalculationModeUsed = Mode,
            PredictedConsumption = predictedConsumption,
            Slope = m, // Incluimos la pendiente en la respuesta para que el cliente pueda entender la fuerza de la tendencia
            InterpretationMessage = interpretation,
        };
    }
}
