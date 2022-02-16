namespace RandomColor;

public class ColorLibrary
{
    private readonly Dictionary<EColorScheme, KnownColor> _knownColors;

    public ColorLibrary()
    {
        _knownColors = new Dictionary<EColorScheme, KnownColor>()
        {
            {
                EColorScheme.Monochrome,
                new KnownColor(new Range(0, 0), new Range[]
                {
                    new(0, 0),
                    new(100, 0)
                })
            },
            {
                EColorScheme.Red,
                new KnownColor(new Range(-26, 18), new Range[]
                {
                    new(20, 100),
                    new(30, 92),
                    new(40, 89),
                    new(50, 85),
                    new(60, 78),
                    new(70, 70),
                    new(80, 60),
                    new(90, 55),
                    new(100, 50)
                })
            }
        };
    }
}