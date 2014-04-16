using GamePlayer.Game;

namespace GamePlayer.Engine.Commands
{
    [CommandAttribute("opponent_moves", "Listing of opponent's moves")]
    public class OpponentMovesCommand : ICommand
    {
        public CommandResponse Execute(GameState game, string[] args)
        {
            return new CommandResponse(CommandAction.None); // Noop for now
        }
    }
}
