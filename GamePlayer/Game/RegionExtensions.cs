using System.Collections.Generic;
using System.Linq;

namespace GamePlayer.Game
{
    public static class RegionExtensions
    {
        public static double ArmyRatio(this Region source, Region target)
        {
            return (source.Armies / (double)target.Armies);
        }

        public static IEnumerable<Region> Sheltered(this IEnumerable<Region> regions)
        {
            return regions.Where(r => !r.BoardingUncontrolled.Any());
        }

        public static IEnumerable<Region> BattleFronts(this IEnumerable<Region> regions)
        {
            return regions.Where(r => r.BoardingUncontrolled.Any());
        }
    }
}
