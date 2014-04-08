using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using GamePlayer.Game;

namespace GamePlayer.Botting.Commands
{
    public class CommandManager
    {
        private readonly GameState _game;

        private static readonly Lazy<IList<ICommand>> _commands = new Lazy<IList<ICommand>>(GetCommands);
        private static Dictionary<string, ICommand> _commandCache;

        public CommandManager(GameState game)
        {
            _game = game;
        }

        public CommandResponse HandleCommand(string command)
        {
            string[] args = command.Trim().Split(' ');
            string commandName = args[0];

            return HandleCommand(commandName, args.Skip(1).ToArray());
        }

        private CommandResponse HandleCommand(string commandName, string[] args)
        {
            ICommand command;
            if (!TryMatchCommand(commandName, out command))
                return new CommandResponse(CommandAction.Error, string.Format("Command, {0}, was not found", commandName));
            
            return command.Execute(_game, args);
        }

        private bool TryMatchCommand(string commandName, out ICommand command)
        {
            if (_commandCache == null)
            {
                var commands = from c in _commands.Value
                               let commandAttributes = c.GetType()
                                                       .GetCustomAttributes(true)
                                                       .OfType<CommandAttribute>()
                               where commandAttributes != null
                               select new
                               {
                                   CommandAttributes = commandAttributes,
                                   Command = c
                               };

                _commandCache = new Dictionary<string, ICommand>(StringComparer.OrdinalIgnoreCase);

                foreach(var gameCommands in commands)
                {
                    foreach(var attribute in gameCommands.CommandAttributes)
                        _commandCache.Add(attribute.CommandName, gameCommands.Command);
                }
            }

            return _commandCache.TryGetValue(commandName, out command);
        }

        private static IList<ICommand> GetCommands()
        {
            // Use MEF to locate the content providers in this assembly
            var catalog = new AssemblyCatalog(typeof(CommandManager).Assembly);
            var compositionContainer = new CompositionContainer(catalog);

            return compositionContainer.GetExportedValues<ICommand>().ToList();
        }
    }
}
