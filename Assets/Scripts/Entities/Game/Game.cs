using System;
using System.Collections.Generic;

public class Game
{
    public DateTime StartTime { get; private set; }
    public bool Paused { get; private set; }
    public string ReportPath { get; set; }
    public bool ReportCreated => !string.IsNullOrEmpty(ReportPath);
    public Queue<Level> Levels { get; private set; } = new Queue<Level>();
    public Level CurrentLevel { get; private set; }
    public float Score { get; private set; }

    public Game(DateTime startTime, Queue<Level> levels)
    {
        StartTime = startTime;
        Levels = levels;
    }

    public void Pause() => Paused = true;
    public void Resume() => Paused = false;

    public void AddPoints(int pointValue, float amount)
    {
        Score += pointValue * amount;
    }

    public Level NextLevel()
    {
        CurrentLevel = Levels.Count > 0 ? Levels.Dequeue() : null;
        return CurrentLevel;
    }
}
