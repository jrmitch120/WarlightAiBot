using System;
using System.Collections.Generic;
using System.Linq;
using GamePlayer.Game;

namespace GamePlayer.Botting.StupidBotting
{
    public class StupidBot : Bot, IBot
    {
        private readonly Random _random = new Random();

        public StupidBot()
        {
            BotName = "Sgt. Stupid";
        }

        public Regions PickStartingRegions(Map map, Regions availableOptions)
        {
            int numberToPick = availableOptions.Count > 6 ? 6 : availableOptions.Count;

            var selectedRegions = new Regions();

            availableOptions.OrderBy(x => _random.Next()).Take(numberToPick)
                .ToList()
                .ForEach(selectedRegions.Add);

            return selectedRegions;
        }

        public ArmyPlacements PlaceArmies(Map map)
        {
            var armyPlacements = new ArmyPlacements();

            // Sgt. Stupid dumps everybody to the first region we own
            Region firstRegion = map.Regions.First(r => r.Owner == BotPlayer);

            firstRegion.Armies += BotPlayer.DeployableArmies;
            armyPlacements.Add(new ArmyPlacement(firstRegion, BotPlayer.DeployableArmies));

            BotPlayer.DeployableArmies = 0;

            return armyPlacements;
        }

        public IEnumerable<AttackTransfer> AttackTransfer(Map map)
        {
            var moves = new List<AttackTransfer>();

            // Sgt Stupid does not transfer.  He just attacks!
            foreach(Region ourRegion in map.Regions.OwnedBy(BotPlayer))
            {
                foreach (Region uncontrolled in ourRegion.BoardingAllUncontrolled())
                {
                    if (ourRegion.PossibleAttackTarget(uncontrolled))
                    {
                        moves.Add(new AttackTransfer(ourRegion, uncontrolled, ourRegion.MaxAttackTransfer));
                        break;
                    }
                }
            }

            return moves;
        }
    }
}
