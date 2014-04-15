using GamePlayer.Botting;
using GamePlayer.Botting.StupidBotting;

namespace GamePlayer.Game
{
    public class GameState
    {
        public readonly Map Map = new Map();

        public readonly Players Opponents = new Players();

        private IBot _ai;
        public IBot Bot
        {
            get { return _ai ?? new StupidBot(); }
            set { _ai = value; }
        }
        public int Turn { get; private set; }

        public void BeginNewTurn()
        {
            Turn++;
        }
    }
}
