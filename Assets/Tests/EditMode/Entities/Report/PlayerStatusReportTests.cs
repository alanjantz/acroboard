using NUnit.Framework;

public class PlayerStatusReportTests
{
    [Test]
    [TestCase(14)]
    [TestCase(15)]
    [TestCase(340)]
    [TestCase(341)]
    public void PlayerStatusReport_GetPlayerLookingDirection_ShouldReturnLookingStraightWhenPlayerIsLookingForward(float cameraDirection)
    {
        // Act
        var result = PlayerStatusReport.GetPlayerLookingDirection(cameraDirection);

        // Assert
        Assert.That(result, Is.EqualTo(PlayerLookingDirection.Straight));
    }

    [Test]
    [TestCase(16)]
    [TestCase(89)]
    [TestCase(90)]
    public void PlayerStatusReport_GetPlayerLookingDirection_ShouldReturnLookingDownWhenPlayerIsLookingDown(float cameraDirection)
    {
        // Act
        var result = PlayerStatusReport.GetPlayerLookingDirection(cameraDirection);

        // Assert
        Assert.That(result, Is.EqualTo(PlayerLookingDirection.Down));
    }

    [Test]
    [TestCase(270)]
    [TestCase(271)]
    [TestCase(339)]
    public void PlayerStatusReport_GetPlayerLookingDirection_ShouldReturnLookingUpWhenPlayerIsLookingUp(float cameraDirection)
    {
        // Act
        var result = PlayerStatusReport.GetPlayerLookingDirection(cameraDirection);

        // Assert
        Assert.That(result, Is.EqualTo(PlayerLookingDirection.Up));
    }
}
