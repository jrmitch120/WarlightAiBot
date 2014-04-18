using System.Collections.Generic;
using System.Linq;

namespace GamePlayer.Botting.Common.Scoring
{
    public static class ScoreExtensions
    {
        public static IEnumerable<RegionScore<StartRegion>> OrderByCumulativeScore(this IEnumerable<RegionScore<StartRegion>> scores)
        {
            return scores.OrderByDescending(r => r.Scores.CumulativeScore);
        }
    }
}