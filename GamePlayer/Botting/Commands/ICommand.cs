using System.ComponentModel.Composition;
using GamePlayer.Game;

namespace GamePlayer.Botting.Commands
{
    [InheritedExport]
    public interface ICommand
    {
        CommandResponse Execute(GameState game, string[] args);
    }
}
