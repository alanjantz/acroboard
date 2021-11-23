using NUnit.Framework;
using UnityEngine;

public class LevelTests
{
    [Test]
    public void Level_ContainsPointNear_ShouldReturnFalseWhenPointDistanceIsFurtherThanMinDistance()
    {
        // Arrange
        var level = new Level(1);
        level.AddPoint(new Vector3(1, 1, 1));
        var anotherPoint = new Vector3(1, 2 + Level.MinDistance, 1);

        // Act
        var result = level.ContainsPointNear(anotherPoint);

        // Assert
        Assert.That(result, Is.False);
    }

    [Test]
    public void Level_ContainsPointNear_ShouldReturnTrueWhenPointDistanceIsCloserThanMinDistance()
    {
        // Arrange
        var level = new Level(1);
        level.AddPoint(new Vector3(1, 1, 1));
        var anotherPoint = new Vector3(1, 4, 1);

        // Act
        var result = level.ContainsPointNear(anotherPoint);

        // Assert
        Assert.That(result, Is.True);
    }
}
