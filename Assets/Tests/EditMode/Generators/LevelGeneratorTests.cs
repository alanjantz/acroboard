using NUnit.Framework;

public class LevelGeneratorTests
{
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    public void LevelGenerator_Generate_ShouldGenerateExpectedAmount(int levelsAmount)
    {
        // Act
        var generatedLevels = LevelGenerator.Genetare(levelsAmount);

        // Assert
        Assert.That(generatedLevels.Count, Is.EqualTo(levelsAmount));
    }

    [Test]
    public void LevelGenerator_Generate_ShouldGenerateExpectedPointsAmount()
    {
        // Arrange
        var expectedResult = new int[]
        {
            3, 4, 5, 5, 6, 6, 7, 8
        };

        // Act
        var generatedLevels = LevelGenerator.Genetare(8);

        // Assert
        for (int i = 0; i < generatedLevels.Count; i++)
        {
            Assert.That(generatedLevels.Dequeue().Positions.Count, Is.EqualTo(expectedResult[i]));
        }
    }
}
