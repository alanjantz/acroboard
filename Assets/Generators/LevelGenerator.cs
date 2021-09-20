using System;
using System.Collections.Generic;
using System.Linq;

public static class LevelGenerator
{
    private static readonly Dictionary<int, List<LevelPointRange>> pointRangePerLevel = new Dictionary<int, List<LevelPointRange>>()
    {
        [0] = PointRangeGenerator.Generate(3, 01, 10),
        [1] = PointRangeGenerator.Generate(4, 10, 20),
        [2] = PointRangeGenerator.Generate(5, 20, 30),
        [3] = PointRangeGenerator.Generate(5, 30, 40),
        [4] = PointRangeGenerator.Generate(6, 40, 50),
        [5] = PointRangeGenerator.Generate(6, 50, 60),
        [6] = PointRangeGenerator.Generate(7, 60, 70),
        [7] = PointRangeGenerator.Generate(8, 70, 80),
    };

    private static readonly List<LevelPointRange> defaultPointRanges = PointRangeGenerator.Generate(5, 1, PlayerMoviment.MaxHeight);

    public static Queue<Level> Genetare(DateTime startTime, int amount = 8)
    {
        var result = new Queue<Level>();

        for (int stage = 0; stage < amount; stage++)
        {
            var level = new Level(stage + 1);

            List<LevelPointRange> pointsRange = defaultPointRanges;

            if (pointRangePerLevel.ContainsKey(stage))
                pointsRange = pointRangePerLevel[stage];

            level.AddPoints(pointsRange.Select(pr => pr.GetRandomRange()));

            result.Enqueue(level);
        }

        result.First().SetStartTime(startTime);

        return result;
    }
}
