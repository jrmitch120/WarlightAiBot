using System.Collections.Generic;
using GamePlayer.Game;

namespace GamePlayer.Botting.Common.Scoring
{
    public interface IScoresCalculator
    {
        IEnumerable<RegionScore<StartRegion>> CalculateStartRegions(Map map);
        IEnumerable<RegionScore<Deployment>> CalculateDeployments(Map map, Player targetPlayer);
        IEnumerable<RegionScore<Desirability>> CalculateDesirability(Map map, Player targetPlayer);
    }
}