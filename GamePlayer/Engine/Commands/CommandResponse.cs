namespace GamePlayer.Engine.Commands
{
    public class CommandResponse
    {
        public readonly CommandAction Action;
        
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