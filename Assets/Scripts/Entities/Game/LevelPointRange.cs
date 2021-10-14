using UnityEngine;

public class LevelPointRange
{
    public Vector3 Min { get; private set; }
    public Vector3 Max { get; private set; }

    public LevelPointRange(Vector3 min, Vector3 max)
    {
        Min = min;
        Max = max;
    }

    public Vector3 GetRandomRange()
    {
        var randomizer = new System.Random();

        return new Vector3(randomizer.NextFloat(Min.x, Max.x), randomizer.NextFloat(Min.y, Max.y), randomizer.NextFloat(Min.z, Max.z));
    }
}
