using System;
using System.Collections.Generic;
using GamePlayer.Botting.Common.Scoring;
using GamePlayer.Game;
using System.Linq;

namespace GamePlayer.Botting.CptnCompetent
{
    public class CptnCompetentBot : Bot, IBot
    {
        private readonly IScoresCalculator _calc;

        public CptnCompetentBot()
        {
            _calc = new StandardCalculator();
        }

        public IEnumerable<AttackTransfer> AttackTransfer(Map map)
        {
            throw new NotImplementedException();
        }

        public Regions PickStartingRegions(Map map, Regions availableOptions)
        {
            int numberToPick = availableOptions.Count > 6 ? 6 : availableOptions.Count;

            IEnumerable<RegionScore<StartRegion>> scores = _calc.CalculateStartRegions(map);

            var pickList = new Regions();

            pickList.AddRange(scores
                .OrderByCumulativeScore()
                .Where(r => availableOptions.Contains(r.Region))
                .Select(r => r.Region)
                .Take(numberToPick));

            return pickList;
        }

        public IEnumerable<ArmyPlacement> PlaceArmies(Map map)
        {
            var placements = new List<ArmyPlacement>();

            IEnumerable<RegionScore<Deployment>> top3 =
                _calc.CalculateDeployments(map, BotPlayer)
                .OrderBy(s => s.Scores.CumulativeScore)
                .Take(3)
                .ToList();

            // Only deal with the top 3 placements
            double top3TotalScore = top3.Sum(s => s.Scores.CumulativeScore);

            // Total number of deployable armies.  For calculating army allocation percentages.
            int deployableArmies = BotPlayer.DeployableArmies;

            foreach (RegionScore<Deployment> deployment in top3)
            {
                // Deploy armies based on their score % of the total.
                var armies = (int)Math.Floor((deployment.Scores.CumulativeScore/top3TotalScore) * deployableArmies);

                BotPlayer.DeployableArmies -= armies;

                placements.Add(new ArmyPlacement(deployment.Region, armies));
            }

            // Cleanup
            if (BotPlayer.DeployableArmies != 0)
            {
                placements[0].Armies += BotPlayer.DeployableArmies;
                BotPlayer.DeployableArmies = 0;
            }

            return placements;
        }
    }
}
