using NUnit.Framework;

namespace RandomColor.Testing;

public class RandomColorTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Generates_A_Random_Color()
    {
        var color = RandomColor.Get();
        
        Assert.IsNotNull(color);
    }
    
    [Test]
    public void Generates_A_Random_Color_With_Seed()
    {
        var color = RandomColor.Get(seed: 123124);
        var color2 = RandomColor.Get(seed: 123124);
        
        Assert.AreEqual(color, color2);
    }
}