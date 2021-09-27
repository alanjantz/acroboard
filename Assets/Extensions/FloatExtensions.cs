using System;

public static class FloatExtensions
{
    public static double GetHeightValue(this float height, float divisor = 2.5f)
        => Math.Truncate(height / divisor);

    public static double GetHeightValue(this float height, float maxHeight, float divisor = 2.5f)
    {
        float equivalentMaxHeight = maxHeight / divisor;

        var result = height / divisor;

        if (result >= equivalentMaxHeight - 0.5f)
            return Math.Ceiling(equivalentMaxHeight);

        return Math.Truncate(result);
    }
}
