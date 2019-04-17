public static class NihilRandom
{
    private static System.Random rng = new System.Random();

    public static int Int(int start, int end)
    {
        return rng.Next(start, end);
    }

    public static float Float(float start = 0, float end = 1)
    {
        return (float) Double((double) start, (double) end);
    }

    public static double Double(double start = 0, double end = 1)
    {
        double range = end - start;
        double sample = rng.NextDouble();
        double scaled = start + (range * sample);
        return scaled;
    }
}