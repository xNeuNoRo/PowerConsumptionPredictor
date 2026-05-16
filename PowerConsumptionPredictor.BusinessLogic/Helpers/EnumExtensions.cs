using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace PowerConsumptionPredictor.WebApp.Helpers;

public static class EnumExtensions
{
    /// <summary>
    /// Obtiene el nombre de un enum utilizando el atributo Display,
    /// o devuelve el nombre del valor si no se encuentra el atributo.
    /// </summary>
    public static string GetDisplayName(this Enum enumValue)
    {
        return enumValue
                .GetType()
                .GetMember(enumValue.ToString())[0]
                .GetCustomAttribute<DisplayAttribute>()
                ?.Name
            ?? enumValue.ToString();
    }
}
