using GamePlayer.Game;

namespace GamePlayer.Engine.Commands
{
    [CommandAttribute("quit", "Quit the program")]
    public class QuitCommand : ICommand
    {
        public CommandResponse Execute(GameState game, string[] args)
        {
            return new CommandResponse(CommandAction.Quit);
        }
    }
}
