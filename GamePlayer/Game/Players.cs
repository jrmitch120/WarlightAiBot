using System;
using System.Collections;
using System.Collections.Generic;

namespace GamePlayer.Game
{
    public class Players : IEnumerable<Player>
    {
        private readonly Dictionary<int, Player> _players = new Dictionary<int, Player>();

        public Player this[int id]
        {
            get
            {
                try
                {
                    return _players[id];
                }
                catch (ArgumentException ex)
                {
                    throw new GameException("Player does not exist", ex);
                }
            }
        }

        public void AddPlayer(Player player)
        {
            try
            {
                _players.Add(player.Id, player);
            }
            catch (ArgumentException ex)
            {
                throw new GameException("Player already exists", ex);
            }
        }

        public IEnumerator<Player> GetEnumerator()
        {
            return _players.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
