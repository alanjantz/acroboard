using System;

[Serializable]
public class ReportLevelPoint
{
    public string Timestamp;
    public double PlayerHeight;
    public double PointHeight;

    public ReportLevelPoint(DateTime timestamp, double playerHeight, double pointHeight)
    {
        Timestamp = timestamp.ToFullString();
        PlayerHeight = playerHeight;
        PointHeight = pointHeight;
    }
}
