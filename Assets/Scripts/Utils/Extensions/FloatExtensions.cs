public static class FloatExtensions
{
    public static double GetHeightValue(this float height, float divisor = 2.5f)
        => height / divisor;
}
