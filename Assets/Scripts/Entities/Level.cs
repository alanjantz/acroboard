using System;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public List<Vector3> Positions { get; private set; } = new List<Vector3>();
    public DateTime? StartTime { get; private set; }
    public int Stage { get; private set; }

    public const float MinDistance = 5f;

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

    public void AddPoint(Vector3 position)
    {
        Positions.Add(position);
    }

    public override string ToString()
    {
        return $"{StartTime:dd/MM/yyyy HH:mm:ss} - {Positions.Count} position(s)";
    }

    public bool ContainsPointNear(Vector3 randomPoint)
    {
        foreach (var point in Positions)
        {
            Debug.LogWarning($"A distância entre {randomPoint} e {point} é de {Vector3.Distance(randomPoint, point)}");
            if (Vector3.Distance(randomPoint, point) <= MinDistance)
                return true;
        }
        return false;
    }
}
