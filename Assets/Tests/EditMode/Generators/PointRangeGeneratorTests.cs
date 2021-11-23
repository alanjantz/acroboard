using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PointRangeGeneratorTests
{
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    public void PointRangeGenerator_Generate_ShouldGenerateExpectedAmount(int pointsAmount)
    {
        // Act
        var generatedPoints = PointRangeGenerator.Generate(pointsAmount, 0, 1);

        // Assert
        Assert.That(generatedPoints.Count, Is.EqualTo(pointsAmount));
    }

    [Test]
    public void LevelGenerator_Generate_ShouldGeneratePointsAboveMinimumHeight()
    {
        // Arrange
        float minHeight = 1;

        // Act
        var generatedPoints = PointRangeGenerator.Generate(3, minHeight, minHeight + 10);

        // Assert
        foreach (var point in generatedPoints)
        {
            Assert.That(point.Min.y, Is.GreaterThanOrEqualTo(minHeight));
        }
    }

    [Test]
    public void LevelGenerator_Generate_ShouldGeneratePointsUnderMaximumHeight()
    {
        // Arrange
        float maxHeight = 10;

        // Act
        var generatedPoints = PointRangeGenerator.Generate(3, maxHeight - 10, maxHeight);

        // Assert
        foreach (var point in generatedPoints)
        {
            Assert.That(point.Max.y, Is.LessThanOrEqualTo(maxHeight));
        }
    }
}
