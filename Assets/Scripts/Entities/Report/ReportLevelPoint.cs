using System;

public class ReportLevelPoint
{
    public DateTime Timestamp { get; protected set; }
    public double PlayerHeight { get; protected set; }
    public double PointHeight { get; protected set; }

    public ReportLevelPoint(DateTime timestamp, double playerHeight, double pointHeight)
    {
        Timestamp = timestamp;
        PlayerHeight = playerHeight;
        PointHeight = pointHeight;
    }
}
