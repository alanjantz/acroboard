using System;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public List<Vector3> Positions { get; private set; } = new List<Vector3>();
    public DateTime? StartTime { get; private set; }
    public int Stage { get; private set; }

    public Level(int stage)
    {
        SetStage(stage);
    }

    public Level(int stage, DateTime startTime) : this(stage)
    {
        SetStartTime(startTime);
    }

    public void SetStage(int stage)
    {
        this.Stage = stage;
    }

    public void SetStartTime(DateTime startTime)
    {
        StartTime = startTime;
    }

    public void AddPoints(IEnumerable<Vector3> positions)
    {
        Positions.AddRange(positions);
    }

    public override string ToString()
    {
        return $"{StartTime:dd/MM/yyyy HH:mm:ss} - {Positions.Count} position(s)";
    }
}
