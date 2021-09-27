using System;
using System.Collections.Generic;

public class ReportLevel
{
    public int Stage { get; set; }
    public DateTime StartTime { get; private set; }
    public DateTime EndTime { get; private set; }
    public List<ReportLevelPoint> Points { get; protected set; } = new List<ReportLevelPoint>();

    public ReportLevel(int stage, DateTime startTime)
    {
        Stage = stage;
        StartTime = startTime;
    }

    public void EndLevel(DateTime endTime)
    {
        EndTime = endTime;
    }

    public void AddPoint(DateTime timestamp)
    {
        Points.Add(new ReportLevelPoint(timestamp));
    }
}
