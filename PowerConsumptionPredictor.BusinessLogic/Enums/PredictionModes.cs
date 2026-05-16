using System.ComponentModel.DataAnnotations;

namespace PowerConsumptionPredictor.BusinessLogic.Enums;

public enum PredictionMode
{
    [Display(Name = "Promedio Movil Simple (SMA)")]
    SimpleMovingAverage = 1,

    [Display(Name = "Regresion Lineal")]
    LinearRegression = 2,

    [Display(Name = "Variacion Porcentual")]
    PercentageVariation = 3,

    [Display(Name = "Deteccion de Tendencias")]
    TrendDetection = 4,
}
