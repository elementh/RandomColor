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
            },
            {
                EColorScheme.Orange,
                new KnownColor(new Range(19, 46), new Range[]
                {
                    new(20, 100),
                    new(30, 93),
                    new(40, 88),
                    new(50, 86),
                    new(60, 85),
                    new(70, 70),
                    new(100, 70)
                })
            },
            {
                EColorScheme.Yellow,
                new KnownColor(new Range(47, 62), new Range[]
                {
                    new(20, 100),
                    new(30, 93),
                    new(40, 88),
                    new(50, 86),
                    new(60, 85),
                    new(70, 70),
                    new(100, 70)
                })
            },
            {
                EColorScheme.Green,
                new KnownColor(new Range(63, 178), new Range[]
                {
                    new(30, 100),
                    new(40, 90),
                    new(50, 85),
                    new(60, 81),
                    new(70, 74),
                    new(80, 64),
                    new(90, 50),
                    new(100, 40)
                })
            },
            {
                EColorScheme.Blue,
                new KnownColor(new Range(-26, 18), new Range[]
                {
                    new(20, 100),
                    new(30, 86),
                    new(40, 80),
                    new(50, 74),
                    new(60, 60),
                    new(70, 52),
                    new(80, 44),
                    new(90, 39),
                    new(100, 35)
                })
            }
        };
    }
}