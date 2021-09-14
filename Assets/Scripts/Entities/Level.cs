using System;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public List<Vector3> Positions { get; private set; } = new List<Vector3>();
    public DateTime? StartTime { get; private set; }

    public Level() { }

    public Level(DateTime startTime)
    {
        SetStartTime(startTime);
    }

    public void SetStartTime(DateTime startTime)
    {
        StartTime = startTime;
    }

    public void Add(Vector3 position)
    {
        Positions.Add(position);
    }

    public override string ToString()
    {
        return $"{StartTime:dd/MM/yyyy HH:mm:ss} - {Positions.Count} position(s)";
    }
}
