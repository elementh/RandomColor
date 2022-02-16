using System.Drawing;

namespace RandomColor;

/// <summary>
/// Provider of attractive random colors.
/// </summary>
public interface IRandomColor
{
    /// <summary>
    /// Generates a random color. Optionally specify a color scheme and/or the luminosity of the desired color.
    /// </summary>
    /// <param name="scheme"><see cref="EColorScheme"/>.</param>
    /// <param name="luminosity"><see cref="ELuminosity"/>.</param>
    /// <returns>A random color in the form of <see cref="Color"/>.</returns>
    Color Generate(EColorScheme? scheme = default, ELuminosity? luminosity = default);
}