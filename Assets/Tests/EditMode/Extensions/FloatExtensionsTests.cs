using NUnit.Framework;

public class FloatExtensionsTests
{
    [Test]
    [TestCase(1, 0.4)]
    [TestCase(2, 0.8)]
    [TestCase(3, 1.2)]
    [TestCase(4, 1.6)]
    [TestCase(5, 2)]
    public void FloatExtensions_GetHeightValue_ShouldReturnCorrectHeight(float value, double expected)
    {
        // Act
        var height = value.GetHeightValue();

        // Assert
        Assert.AreEqual(height, expected);
    }

    [Test]
    [TestCase(1, 1)]
    [TestCase(2, 2)]
    [TestCase(3, 3)]
    [TestCase(4, 4)]
    [TestCase(5, 5)]
    public void FloatExtensions_GetHeightValue_ShouldReturnCorrectHeightWithDifferentDivider(float value, double expected)
    {
        // Arrange
        float divider = 1f;

        // Act
        var height = value.GetHeightValue(divider);

        // Assert
        Assert.AreEqual(height, expected);
    }
}
