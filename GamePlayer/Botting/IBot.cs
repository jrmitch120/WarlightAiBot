using GamePlayer.Game;

namespace GamePlayer.Botting
{
    public interface IBot
    {
        string BotName { get; set; }
        Regions PickStartingRegions(Map map, Regions availableOptions);
    }
}
