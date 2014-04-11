using System;
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
    }
}
