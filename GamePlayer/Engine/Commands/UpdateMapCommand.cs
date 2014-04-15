using GamePlayer.Game;
using System.Linq;

namespace GamePlayer.Engine.Commands
{
    [CommandAttribute("update_map", "Update the map state")]
    public class UpdateMapCommand : ICommand
    {
        public CommandResponse Execute(GameState game, string[] args)
        {
            var updatedRegions = new Regions();

            // Update visible regions
            for (int i = 0; i < args.Length; i += 3)
            {
                int regionId = int.Parse(args[i]);
                int armies = int.Parse(args[i + 2]);
                string ownerId = args[i + 1];

                Region region = game.Map.Regions[regionId];
                
                region.Armies = armies;
                region.IsVisible = true;

                if (ownerId == "neutral")
                    region.Owner = null;
                else
                    region.Owner = ownerId == game.Bot.BotPlayer.Id ? game.Bot.BotPlayer : game.Opponents[args[i + 1]];

                updatedRegions.Add(region);
            }

            // Mark invisible regions as such.  Leave the previous info in place for now.
            game.Map.Regions.Except(updatedRegions).ToList().ForEach(r =>
            {
                r.IsVisible = false;
            });
           
            return new CommandResponse(CommandAction.None);
        }
    }
}
