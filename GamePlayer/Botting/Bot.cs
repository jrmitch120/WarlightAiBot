using GamePlayer.Botting.Commands;
using GamePlayer.Game;

namespace GamePlayer.Botting
{
    public class Bot
    {
        private readonly CommandManager _commandManager;

        public Bot(GameState game)
        {
            _commandManager = new CommandManager(game);
        }

        public CommandResponse ProcessCommand(string command)
        {
            return (_commandManager.HandleCommand(command));
        }
    }
}
