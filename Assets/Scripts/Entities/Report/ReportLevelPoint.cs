using System;

public class ReportLevelPoint
{
    public DateTime Timestamp { get; protected set; }

    public ReportLevelPoint(DateTime timestamp)
    {
        Timestamp = timestamp;
    }
}
