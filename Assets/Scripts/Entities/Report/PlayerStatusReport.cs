using System;

[Serializable]
public class PlayerStatusReport
{
    public DateTime Timestamp { get; protected set; }
    public double Height { get; protected set; }
    public PlayerLookingDirection LookingDirection { get; protected set; }

    public PlayerStatusReport(DateTime timestamp, double height, PlayerLookingDirection playerLookingDirection)
    {
        Timestamp = timestamp;
        Height = height;
        LookingDirection = playerLookingDirection;
    }

    public static PlayerLookingDirection GetPlayerLookingDirection(float cameraRotation)
    {
        if (cameraRotation <= 15 || cameraRotation >= 340)
            return PlayerLookingDirection.Straight;

        if (cameraRotation > 15 && cameraRotation <= 90)
            return PlayerLookingDirection.Down;

        if (cameraRotation >= 270 && cameraRotation < 340)
            return PlayerLookingDirection.Up;

        return PlayerLookingDirection.Straight;
    }
}
