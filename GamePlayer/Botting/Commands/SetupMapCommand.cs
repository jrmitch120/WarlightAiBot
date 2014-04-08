using System;
using GamePlayer.Game;

namespace GamePlayer.Botting.Commands
{
    [CommandAttribute("setup_map", "Map setup")]
    public class SetupMapCommand : ICommand
    {
        public CommandResponse Execute(GameState game, string[] args)
        {
            switch (args[0])
            {
                case "super_regions":
                    for (int i = 1; i < args.Length; i++)
                    {
                        int id = Int32.Parse(args[i]);
                        int bonus = Int32.Parse(args[i + 1]);

                        game.Map.SuperRegions.AddSuperRegion(new SuperRegion(Int32.Parse(args[i]), Int32.Parse(args[i + 1])));

                        i++;
                    }
                    break;

                case "regions":
                    for (int i = 1; i < args.Length; i++)
                    {
                        SuperRegion superRegion = game.Map.SuperRegions[Int32.Parse(args[i])];

                        int regionId = Int32.Parse(args[i + 1]);

                        superRegion.Regions.AddRegion(new Region(regionId, superRegion));

                        i++;
                    }
                    break;
            }


            return new CommandResponse(CommandAction.None);
        }
    }
}
