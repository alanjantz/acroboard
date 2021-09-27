using System;

public class ReportManager
{
    private static Report _currentReport;

    public static Report GetCurrentReport() => _currentReport;

    public static void CreateReport(int expectedStages)
    {
        _currentReport = new Report(expectedStages);
    }

    public static void AddLevel(Level level)
    {
        _currentReport?.AddLevel(level.Stage, level.StartTime.GetValueOrDefault());
    }

    public static void EndLevel(DateTime endTime)
    {
        if (_currentReport?.HasCurrentLevel ?? false)
            _currentReport.EndLevel(endTime);
    }

    public static void AddPoint()
    {
        _currentReport?.AddPoint(DateTime.Now);
    }
}
