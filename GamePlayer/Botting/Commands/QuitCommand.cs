using GamePlayer.Game;

namespace GamePlayer.Botting.Commands
{
    [CommandAttribute("quit", "Quit the bot program")]
    public class QuitCommand : ICommand
    {
        public CommandResponse Execute(GameState game, string[] args)
        {
            return new CommandResponse(CommandAction.Quit);
        }
    }
}
