using Microsoft.Extensions.DependencyInjection;
using PowerConsumptionPredictor.BusinessLogic.Interfaces;
using PowerConsumptionPredictor.BusinessLogic.Services;
using PowerConsumptionPredictor.BusinessLogic.Strategies;

namespace PowerConsumptionPredictor.BusinessLogic;

public static class DependencyInjection
{
    // Registramos en el container DI los servicios de la capa de negocio
    public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
    {
        // Registramos el servicio de pers. de modo como singleton
        services.AddSingleton<IModePersistenceService, ModePersistenceService>();

        // Registramos las estrategias de prediccion en el container scoped
        // pa q de esa forma se creen nuevas instances por cada req
        services.AddScoped<IPredictionStrategy, SmaStrategy>();
        services.AddScoped<IPredictionStrategy, LinearRegressionStrategy>();
        services.AddScoped<IPredictionStrategy, PercentageVariationStrategy>();
        services.AddScoped<IPredictionStrategy, TrendDetectionStrategy>();

        // Lo mismo pa el contexto de los predictors
        services.AddScoped<IPredictorContext, PredictorContext>();

        return services;
    }
}
