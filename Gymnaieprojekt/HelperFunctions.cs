namespace Gymnaieprojekt
{
    public static class HelperFunctions
    {
        public static double Clamp(double number, double lowInterval, double highInterval)
        {
            if (number < lowInterval) return lowInterval;
            if (number > highInterval) return highInterval;
            return number;
        }
    }
}
