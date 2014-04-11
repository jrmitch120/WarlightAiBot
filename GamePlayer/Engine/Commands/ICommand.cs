using System.ComponentModel.Composition;
using GamePlayer.Game;

namespace GamePlayer.Engine.Commands
{
    [InheritedExport]
    public interface ICommand
    {
        CommandResponse Execute(GameState game, string[] args);
    }
}
