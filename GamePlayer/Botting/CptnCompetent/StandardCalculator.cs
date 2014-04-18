using System;
using System.Collections.Generic;
using System.Linq;
using GamePlayer.Botting.Common;
using GamePlayer.Botting.Common.Scoring;
using GamePlayer.Game;

namespace GamePlayer.Botting.CptnCompetent
{
    public class StandardCalculator : IScoresCalculator
    {
        public IEnumerable<RegionScore<StartRegion>> CalculateStartRegions(Map map)
        {
            var scores = new List<RegionScore<StartRegion>>();

            foreach (Region region in map.Regions)
            {
                var calc = new RegionScore<StartRegion>(region, new StartRegion());

                calc.Scores.SuperRegionScore = 1/(double) region.SuperRegion.Regions.Count*5;
                calc.Scores.DefensibilityScore = 1/(double) region.Neighbors.Count;
                calc.Scores.BorderRegionScore = region.IsBorderRegion ? .2 : 0;

                if (region.IsBorderRegion)
                    calc.Scores.ChokepointScore = 1/(double) region.SuperRegion.BorderRegions.Count();
                else
                    calc.Scores.ChokepointScore = 0;

                scores.Add(calc);
            }

            return scores;
        }

        public IEnumerable<RegionScore<Deployment>> CalculateDeployments(Map map, Player targetPlayer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegionScore<Desirability>> CalculateDesirability(Map map, Player targetPlayer)
        {
            throw new NotImplementedException();
        }
    }
}
