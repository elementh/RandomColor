using System.Drawing;

namespace RandomColor;

public static class RandomColor
{
    private static readonly ColorLibrary ColorLibrary;
    private static Random _random;
    private static bool _randomHasSeed;

    static RandomColor()
    {
        ColorLibrary = new ColorLibrary();
        _random = new Random();
    }

    public static Color Get(EColorScheme? scheme = default, ELuminosity? luminosity = default, int? seed = default)
    {
        if (seed is not null)
        {
            _random = new Random(seed.Value);
            _randomHasSeed = true;
        }
        else if (_randomHasSeed)
        {
            _random = new Random();
            _randomHasSeed = false;
        }

        var hue = PickHue(scheme);
        var saturation = PickSaturation(hue, luminosity);

        throw new NotImplementedException();
    }
    private static int PickHue(EColorScheme? scheme)
    {
        if (scheme is null)
        {
            return _random.Next(0, 361);
        }

        return RandomWithin(ColorLibrary.GetColor(scheme)?.Hue ?? new Range(0, 361));
    }

    private static int PickSaturation(int hue, ELuminosity? luminosity)
    {
        var saturation = ColorLibrary.GetSaturationRange(hue);

        if (luminosity is null)
        {
            return RandomWithin(new Range(0, 100));
        }
        
        return luminosity switch
        {
            ELuminosity.Bright => RandomWithin(new Range(55, saturation.Value.End)),
            ELuminosity.Light => RandomWithin(new Range(saturation.Value.Start, 55)),
            ELuminosity.Dark => RandomWithin(new Range(saturation.Value.End.Value - 10, saturation.Value.End.Value)),
            _ => RandomWithin(saturation.Value)
        };
    }

    private static int RandomWithin(Range range)
    {
        if (range.Start.Value > range.End.Value)
        {
            range = new Range(range.End, range.Start);
        }

        if (range.Start.Value == range.End.Value)
        {
            range = new Range(range.Start, range.End.Value + 1);
        }
        
        return _random.Next(range.Start.Value, range.End.Value + 1);
    }
}