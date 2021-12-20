using System;

[Serializable]
public class PlayerStatusReport
{
    public string Timestamp;
    public double Height;
    public PlayerLookingDirection LookingDirection;

    public PlayerStatusReport(DateTime timestamp, double height, PlayerLookingDirection playerLookingDirection)
    {
        Timestamp = timestamp.ToFullString();
        Height = height;
        LookingDirection = playerLookingDirection;
    }

    public static PlayerLookingDirection GetPlayerLookingDirection(float cameraRotation)
    {
        if (cameraRotation <= 15 || cameraRotation >= 340)
            return PlayerLookingDirection.Forward;

        if (cameraRotation > 15 && cameraRotation <= 90)
            return PlayerLookingDirection.Downward;

        if (cameraRotation >= 270 && cameraRotation < 340)
            return PlayerLookingDirection.Upward;

        return PlayerLookingDirection.Forward;
    }
}
