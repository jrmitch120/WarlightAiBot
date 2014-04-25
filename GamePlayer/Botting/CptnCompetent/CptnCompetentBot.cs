using System;
using System.Collections;
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

        //public IEnumerable<AttackTransfer> AttackTransfer(Map map)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<AttackTransfer> AttackTransfer(Map map)
        {
            
            List<Region> ourRegions = map.Regions.OwnedBy(BotPlayer).ToList();
            var moves = new List<AttackTransfer>();

            foreach (Region ourRegion in ourRegions)
            {
                foreach (Region uncontrolled in ourRegion.BoardingUncontrolled)
                {
                    // If Sgt Stupid's region has a neighbor that's not his, kick their ass if they're out gunned.
                    if (ourRegion.ArmyRatio(uncontrolled) >= 1.5)
                    {
                        moves.Add(new AttackTransfer(ourRegion, uncontrolled, ourRegion.MaxAttackTransfer));
                        break;
                    }
                }
            }


            // Transfer armies from sheltered regions to the closest battlefront
            foreach (Region sheltered in ourRegions.Sheltered().Where(r => r.Armies > GameSettings.MinimumArmies))
            {
                
                List<Region> shortestPath = null;

                foreach (Region battleFront in ourRegions.OrderByDescending(r => r.BoardingEnemyArmies))
                {
                    var path = map.Regions.ShortestPath(sheltered, battleFront, BotPlayer).ToList();

                    if (path.Any() && (shortestPath == null || path.Count() < shortestPath.Count()))
                        shortestPath = path;
                }

                if (shortestPath != null && shortestPath.Any())
                    moves.Add(new AttackTransfer(sheltered, shortestPath[0], sheltered.Armies - GameSettings.MinimumArmies));
            }

            return moves;
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
                .OrderByDescending(s => s.Scores.CumulativeScore)
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
