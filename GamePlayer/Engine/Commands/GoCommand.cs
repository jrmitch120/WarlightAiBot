using System.Text;
using GamePlayer.Botting;
using GamePlayer.Game;

namespace GamePlayer.Engine.Commands
{
    [CommandAttribute("go", "Run decision based commands")]
    public class GoCommand : ICommand
    {
        public CommandResponse Execute(GameState game, string[] args)
        {
            var response = new StringBuilder();

            switch (args[0])
            {
                case "place_armies":
                    foreach (ArmyPlacement placement in game.Bot.PlaceArmies(game.Map))
                        response.AppendFormat("{0} place_armies {1} {2},",
                            game.Bot.BotPlayer.PlayerName, placement.Region.Id, placement.Armies);
                    break;

                case "attack/transfer":
                    foreach (AttackTransfer move in game.Bot.AttackTransfer(game.Map))
                        response.AppendFormat("{0} attack/transfer {1} {2} {3},",
                            game.Bot.BotPlayer.PlayerName, move.Source.Id, move.Target.Id, move.Armies);
                    break;
            }
            
            return new CommandResponse(CommandAction.SendData, response.ToString());
        }
    }
}
