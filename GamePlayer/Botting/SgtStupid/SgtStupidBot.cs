using System;
using System.Collections.Generic;
using System.Linq;
using GamePlayer.Game;

namespace GamePlayer.Botting.SgtStupid
{
    public class SgtStupidBot : Bot, IBot
    {
        private readonly Random _random = new Random();

        public SgtStupidBot()
        {
            BotName = "Sgt. Stupid";
        }

        public Regions PickStartingRegions(Map map, Regions availableOptions)
        {
            int numberToPick = availableOptions.Count > GameSettings.StartingRegions ? GameSettings.StartingRegions : availableOptions.Count;

            var selectedRegions = new Regions();

            // Sgt. Stupid picks random regions from the ones he was provided.
            availableOptions.OrderBy(x => _random.Next()).Take(numberToPick)
                .ToList()
                .ForEach(selectedRegions.Add);

            return selectedRegions;
        }

        public IEnumerable<ArmyPlacement> PlaceArmies(Map map)
        {
            var armyPlacements = new List<ArmyPlacement>();

            // Sgt. Stupid dumps everybody to the first region we own that's on a battle front.  No battlefront, means you won the game, but dump them on anything then.
            Region firstRegion =
                map.Regions.FirstOrDefault(r => r.Owner == BotPlayer && r.BoardingUncontrolled().Any()) ??
                map.Regions.First(r => r.Owner == BotPlayer);

            firstRegion.Armies += BotPlayer.DeployableArmies;
            armyPlacements.Add(new ArmyPlacement(firstRegion, BotPlayer.DeployableArmies));

            BotPlayer.DeployableArmies = 0;

            return armyPlacements;
        }

        public IEnumerable<AttackTransfer> AttackTransfer(Map map)
        {
            var moves = new List<AttackTransfer>();

            // Sgt Stupid does not transfer.  He just attacks, attacks, attacks!!!!
            foreach(Region ourRegion in map.Regions.OwnedBy(BotPlayer))
            {
                foreach (Region uncontrolled in ourRegion.BoardingUncontrolled())
                {
                    // If Sgt Stupid's region has a neighbor that's not his, kick their ass if they're out gunned.
                    if (ourRegion.ArmyRatio(uncontrolled) >= 1.5)
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
