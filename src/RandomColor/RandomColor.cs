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
        var brightness = PickBrightness(hue, saturation, luminosity);

        return BuildColor(hue, saturation, brightness);
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

    private static int PickBrightness(int hue, int saturation, ELuminosity? luminosity)
    {
        var minimumBrightness = ColorLibrary.GetMinimumValue(hue, saturation);

        return luminosity switch
        {
            ELuminosity.Bright => RandomWithin(new Range(minimumBrightness, 100)),
            ELuminosity.Light => RandomWithin(new Range(100 + minimumBrightness / 2, 100)),
            ELuminosity.Dark => RandomWithin(new Range(minimumBrightness, minimumBrightness + 20)),
            _ => RandomWithin(new Range(0, 100))
        };
    }

    private static Color BuildColor(int hue, int saturation, int brightness)
    {
        hue = hue switch
        {
            0 => 1,
            360 => 359,
            _ => hue
        };

        var h = hue / 360d;
        var s = saturation / 100d;
        var v = brightness / 100d;

        var hAsInt = (int)Math.Floor(h * 6.0);
        
        var f = h * 6.0 - hAsInt;
        var p = v * (1.0 - s);
        var q = v * (1.0 - f * s);
        var t = v * (1.0 - (1.0 - f) * s);

        var (r, g, b) = hAsInt switch
        {
            0 => (v, t, p),
            1 => (q, v, p),
            2 => (p, v, t),
            3 => (p, q, v),
            4 => (t, p, v),
            _ => (v, p, q)
        };

        return Color.FromArgb(255, (int)Math.Floor(r * 255.0), (int)Math.Floor(g * 255.0), (int)Math.Floor(b * 255.0));
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