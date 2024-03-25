namespace CodeWF.Tools.Desktop.Converters;

public class IconConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not string icon)
        {
            return AvaloniaProperty.UnsetValue;
        }

        if (Application.Current?.FindResource(icon) is StreamGeometry img)
        {
            return img;
        }

        return AvaloniaProperty.UnsetValue;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return AvaloniaProperty.UnsetValue;
    }
}