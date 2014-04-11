using GamePlayer.Game;

namespace GamePlayer.Engine.Commands
{
    [CommandAttribute("settings", "Game setup information")]
    public class SettingsCommand : ICommand
    {
        public CommandResponse Execute(GameState game, string[] args)
        {
            switch (args[0])
            {
                case "your_bot":
                    game.OurPlayer = new Player(args[1], friendly: true);
                    break;

                case "opponent_bot":
                    game.Opponents.Add(new Player(args[1]));
                    break;

                case "starting_armies":
                    game.BeginNewTurn();
                    game.OurPlayer.DeployableArmies = int.Parse(args[1]);
                    break;
            }

            return new CommandResponse(CommandAction.None);
        }
    }
}
