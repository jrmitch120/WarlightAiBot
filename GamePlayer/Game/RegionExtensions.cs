namespace GamePlayer.Game
{
    public static class RegionExtensions
    {
        public static double ArmyRatio(this Region source, Region target)
        {
            return (source.Armies / (double)target.Armies);
        }
    }
}
