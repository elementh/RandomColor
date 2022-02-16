using System.Drawing;

namespace RandomColor;

public static class RandomColor
{
    private static readonly ColorLibrary ColorLibrary;
    private static readonly Random Random;

    static RandomColor()
    {
        ColorLibrary = new ColorLibrary();
        Random = new Random();
    }

    public static Color Get(EColorScheme? scheme = default, ELuminosity? luminosity = default)
    {
        scheme ??= GetRandomColorScheme();
        luminosity ??= GetRandomLuminosity();
        
        return Color.Transparent;
    }

    private static EColorScheme GetRandomColorScheme()
    {
        var values = Enum.GetValues<EColorScheme>();

        return values[Random.Next(values.Length)];
    }
    private static ELuminosity GetRandomLuminosity()
    {
        var values = Enum.GetValues<ELuminosity>();

        return values[Random.Next(values.Length)];
    }
}