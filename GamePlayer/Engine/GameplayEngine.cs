using GamePlayer.Botting;
using GamePlayer.Engine.Commands;
using GamePlayer.Game;

namespace GamePlayer.Engine
{
    public class GameplayEngine
    {
        private readonly CommandManager _commandManager;

        public GameplayEngine() : this(null) { }

        public GameplayEngine(IBot bot)
        {
            _commandManager = new CommandManager(new GameState {Bot = bot});
        }

        public CommandResponse ProcessCommand(string command)
        {
            return (_commandManager.HandleCommand(command));
        }
    }
}
