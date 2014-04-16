using System;

namespace GamePlayer.Game
{
    public class GameException : Exception
    {
        public GameException(string message) : base(message)
        {
        }

        public GameException(string message, Exception ex) : base(message, ex)
        {
            
        }
    }
}
