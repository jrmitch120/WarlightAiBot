using System;
using System.Linq;
using GamePlayer.Game;

namespace GamePlayer.Engine.Commands
{
    [CommandAttribute("pick_starting_regions", "Select starting regions")]
    public class PickStartingRegionsCommand : ICommand
    {
        public CommandResponse Execute(GameState game, string[] args)
        {
            var availableOptions = new Regions();

            for (int i = 1; i < args.Length; i++)
                availableOptions.Add(game.Map.Regions[int.Parse(args[i])]);
           
            Regions selectedRegions = game.Bot.PickStartingRegions(game.Map, availableOptions);

            return new CommandResponse(CommandAction.SendData,
                string.Join(" ", selectedRegions.Select(r => r.Id.ToString())));
        }
    }
}
