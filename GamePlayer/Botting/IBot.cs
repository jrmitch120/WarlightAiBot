using System.Collections.Generic;
using GamePlayer.Game;

namespace GamePlayer.Botting
{
    public interface IBot
    {
        string BotName { get; set; }

        Player BotPlayer { get; set; }

        IEnumerable<AttackTransfer> AttackTransfer(Map map);
        Regions PickStartingRegions(Map map, Regions availableOptions);
        IEnumerable<ArmyPlacement> PlaceArmies(Map map);
    }
}
