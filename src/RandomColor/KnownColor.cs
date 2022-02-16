namespace RandomColor;

public record KnownColor
{
    public Range Hue { get; init; }
    public Range[] LowerBounds { get; init; }
    public Range Saturation { get; init; }
    public Range Brightness { get; init; }

    public KnownColor(Range hue, Range[] lowerBounds)
    {
        Hue = hue;
        LowerBounds = lowerBounds;

        var saturationMin = LowerBounds[0].Start;
        var saturationMax = LowerBounds[^1].Start;

        Saturation = new Range(saturationMin, saturationMax);

        var brightnessMin = LowerBounds[^1].End;
        var brightnessMax = LowerBounds[0].End;

        Brightness = new Range(brightnessMin, brightnessMax);
    }

    public bool Includes(int hue)
    {
        return hue >= Hue.Start.Value && hue <= Hue.End.Value;
    }
}