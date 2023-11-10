using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace SunBoyMusicStore.Models.Base;

public class AttributeConverter: IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null || parameter == null)
            return null;
        Type type = parameter.ToString() switch
        {
            "Genre" => typeof(Genre),
            "Album" => typeof(Album),
            "Artist" => typeof(Artist),
            "Int" => typeof(Int32),
            "TimeSpan" => typeof(TimeSpan),
            "DateTime" => typeof(DateTime),
            _ => typeof(String)
        };

        return System.Convert.ChangeType(value, type);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}