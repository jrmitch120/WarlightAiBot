namespace GamePlayer.Botting.Commands
{
    public class CommandResponse
    {
        public CommandAction Action { get; private set; }
        public string ResponseData { get; private set; }

        public CommandResponse(CommandAction botAction)
        {
            Action = botAction;
        }

        public CommandResponse(CommandAction botAction, string responseData)
        {
            Action = botAction;
            ResponseData = responseData;
        }
    }
}