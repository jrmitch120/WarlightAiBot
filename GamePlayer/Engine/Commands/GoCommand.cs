using GamePlayer.Game;

namespace GamePlayer.Engine.Commands
{
    [CommandAttribute("go", "Run decision based commands")]
    public class GoCommand : ICommand
    {
        public CommandResponse Execute(GameState game, string[] args)
        {
            switch (args[0])
            {
                case "place_armies":
                    break;

                case "attack/transfer":
                    break;
            }

            return new CommandResponse(CommandAction.SendData, "");
        }
    }
}
