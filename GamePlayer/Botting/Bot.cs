using GamePlayer.Game;

namespace GamePlayer.Botting
{
    public abstract class Bot
    {
        private string _botName;
        public string BotName
        {
            get { return _botName ?? "The No-Named Bot"; }
            set { _botName = value; }
        }
    }
}
