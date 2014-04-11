using GamePlayer.Game;

namespace GamePlayer.Engine.Commands
{
    [CommandAttribute("setup_map", "Map setup")]
    public class SetupMapCommand : ICommand
    {
        public CommandResponse Execute(GameState game, string[] args)
        {
            switch (args[0])
            {
                case "super_regions":
                    for (int i = 1; i < args.Length; i += 2)
                        game.Map.SuperRegions.Add(new SuperRegion(int.Parse(args[i]), int.Parse(args[i + 1])));
                    break;

                case "regions":
                    for (int i = 1; i < args.Length; i += 2)
                        game.Map.Regions.Add(new Region(int.Parse(args[i]), game.Map.SuperRegions[int.Parse(args[i + 1])]));
                    break;

                case "neighbors":
                    for (int i = 1; i < args.Length; i+=2)
                    {
                        var region = game.Map.Regions[int.Parse(args[i])];

                        foreach (string neighborId in args[i + 1].Split(new[] {','}))
                        {
                            var neighbor = game.Map.Regions[int.Parse(neighborId)];

                            region.Neighbors.Add(neighbor);
                            neighbor.Neighbors.Add(region);
                        }
                    }

                    break;
            }

            return new CommandResponse(CommandAction.None);
        }
    }
}
