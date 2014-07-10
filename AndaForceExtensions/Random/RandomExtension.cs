namespace AndaForceUtils.Random
{
    public static class RandomExtensions
    {
        public static double NextDoubleInRange(this System.Random random, double minValue, double maxValue)
        {
            return random.NextDouble() * (maxValue - minValue) + minValue;
        }

        public static float NextDoubleInRange(this System.Random random, float minValue, float maxValue)
        {
            return (float) random.NextDouble() * (maxValue - minValue) + minValue;
        }
    }
}