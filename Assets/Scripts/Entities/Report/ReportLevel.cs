using System;
using System.Collections.Generic;

[Serializable]
public class ReportLevel
{
    public int Stage;
    public string StartTime;
    public string EndTime;
    public List<ReportLevelPoint> Points;

    public ReportLevel(int stage, DateTime startTime)
    {
        Points = new List<ReportLevelPoint>();
        Stage = stage;
        StartTime = startTime.ToFullString();
    }

    public void EndLevel(DateTime endTime)
    {
        EndTime = endTime.ToFullString();
    }

    public void AddPoint(DateTime timestamp, double playerHeight, double pointHeight)
    {
        Points.Add(new ReportLevelPoint(timestamp, playerHeight, pointHeight));
    }
}
