using GamePlayer.Game;

namespace GamePlayer.Botting
{
    public abstract class Bot
    {
        public Player BotPlayer { get; set; }

        private string _botName;
        public string BotName
        {
            get { return _botName ?? "The No-Named Bot"; }
            set { _botName = value; }
        }
    }
}
