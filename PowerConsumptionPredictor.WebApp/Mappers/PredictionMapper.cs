using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses;
using PowerConsumptionPredictor.BusinessLogic.DTOs.Responses.Base;
using PowerConsumptionPredictor.WebApp.Models.Results;
using PowerConsumptionPredictor.WebApp.Models.Results.Base;

namespace PowerConsumptionPredictor.WebApp.Mappers;

public static class PredictionMapper
{
    public static BaseResultViewModel ToViewModel(this BasePredictionResponseDto response)
    {
        return response switch
        {
            SmaPredictionResponseDto sma => new SmaResultViewModel
            {
                CalculationModeUsed = sma.CalculationModeUsed,
                InterpretationMessage = sma.InterpretationMessage,
                PredictedConsumption = sma.PredictedConsumption,
            },
            LinearRegressionPredictionResponseDto lr => new LinearRegressionResultViewModel
            {
                CalculationModeUsed = lr.CalculationModeUsed,
                InterpretationMessage = lr.InterpretationMessage,
                PredictedConsumption = lr.PredictedConsumption,
                Slope = lr.Slope,
            },
            PercentageVariationPredictionResponseDto pv => new PercentageVariationResultViewModel
            {
                CalculationModeUsed = pv.CalculationModeUsed,
                InterpretationMessage = pv.InterpretationMessage,
                AveragePercentageVariation = pv.AveragePercentageVariation,
                MonthlyVariations = pv
                    .MonthlyVariations.Select(v => new MonthlyVariationItemViewModel
                    {
                        MonthNumber = v.MonthNumber,
                        VariationText = v.VariationText,
                        VariationValue = v.VariationValue,
                    })
                    .ToList(),
            },
            TrendDetectionPredictionResponseDto td => new TrendDetectionResultViewModel
            {
                CalculationModeUsed = td.CalculationModeUsed,
                InterpretationMessage = td.InterpretationMessage,
                Increases = td.Increases,
                Decreases = td.Decreases,
                StableMonths = td.StableMonths,
                GeneralTrend = td.GeneralTrend,
            },
            _ => throw new InvalidOperationException(
                "El sistema recibio un tipo de calculo no soportado."
            ),
        };
    }
}
