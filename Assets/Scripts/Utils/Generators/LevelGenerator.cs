using System.Collections.Generic;

public static class LevelGenerator
{
    private static readonly Dictionary<int, List<LevelPointRange>> pointRangePerLevel = new Dictionary<int, List<LevelPointRange>>()
    {
        [0] = PointRangeGenerator.Generate(3, 01, 10),
        [1] = PointRangeGenerator.Generate(4, 05, 25),
        [2] = PointRangeGenerator.Generate(5, 15, 35),
        [3] = PointRangeGenerator.Generate(5, 25, 45),
        [4] = PointRangeGenerator.Generate(6, 35, 55),
        [5] = PointRangeGenerator.Generate(6, 45, 65),
        [6] = PointRangeGenerator.Generate(7, 55, 75),
        [7] = PointRangeGenerator.Generate(8, 65, 85),
    };

    private static readonly List<LevelPointRange> defaultPointRanges = PointRangeGenerator.Generate(5, 1, Platform.MaxHeight);

    public static Queue<Level> Genetare(int amount)
    {
        var result = new Queue<Level>();

        for (int stage = 0; stage < amount; stage++)
        {
            var level = new Level(stage + 1);

            List<LevelPointRange> pointsRange = defaultPointRanges;

            if (pointRangePerLevel.ContainsKey(stage))
                pointsRange = pointRangePerLevel[stage];

            foreach (var pointRange in pointsRange)
            {
                var randomPoint = pointRange.GetRandomRange();

                while (level.ContainsPointNear(randomPoint))
                    randomPoint = pointRange.GetRandomRange();

                level.AddPoint(randomPoint);
            }

            result.Enqueue(level);
        }

        return result;
    }
}
