using System.Globalization;
using System.Windows.Data;
using WaterTestProject.Common.Extensions;

namespace WaterTestProject.Converters;

public class EnumDescriptionConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is Enum elem ? elem.GetDescription() : null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null || !targetType.IsEnum)
            return null;

        foreach (var enumValue in Enum.GetValues(targetType))
            if (((Enum)enumValue).GetDescription() == value.ToString())
                return enumValue;
        return Enum.Parse(targetType, value.ToString());
    }
}