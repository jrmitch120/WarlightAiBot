namespace GamePlayer.Game
{
    public static class RegionExtensions
    {
        public static bool PossibleAttackTarget(this Region source, Region target)
        {
            return (source.Armies > target.Armies*1.5);
        }
    }
}
