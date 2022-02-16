namespace RandomColor;

/// <summary>
/// Known color and it's ranges.
/// </summary>
public record KnownColor
{
    /// <summary>
    /// Hue range.
    /// </summary>
    public Range Hue { get; init; }
    
    /// <summary>
    /// Lower bounds.
    /// </summary>
    public Range[] LowerBounds { get; init; }
    
    /// <summary>
    /// Saturation.
    /// </summary>
    public Range Saturation { get; init; }
    
    /// <summary>
    /// Brightness.
    /// </summary>
    public Range Brightness { get; init; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    /// <param name="hue">The hue range of the color.</param>
    /// <param name="lowerBounds">The lower bounds of the color.</param>
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

    /// <summary>
    /// Determines if the hue value passed to the function is inside the hue range of this color.
    /// </summary>
    /// <param name="hue"></param>
    /// <returns>True if inside the range, false otherwise.</returns>
    public bool Includes(int hue)
    {
        return hue >= Hue.Start.Value && hue <= Hue.End.Value;
    }
}