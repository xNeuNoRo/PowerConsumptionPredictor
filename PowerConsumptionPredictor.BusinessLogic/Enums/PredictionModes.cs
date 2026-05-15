namespace PowerConsumptionPredictor.BusinessLogic.Enums;

public enum PredictionMode
{
    SimpleMovingAverage = 1,
    LinearRegression = 2,
    PercentageVariation = 3,
    TrendDetection = 4,
}
