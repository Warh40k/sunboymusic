using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace SunBoyMusicStore.Models.Base;

public class ComboboxConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value != null)
        {
            return ((Attribute)value).Name;
        }

        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}