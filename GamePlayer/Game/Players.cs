using System;
using System.Collections;
using System.Collections.Generic;

namespace GamePlayer.Game
{
    public class Players : IEnumerable<Player>
    {
        private readonly Dictionary<string, Player> _players = new Dictionary<string, Player>();

        public Player this[string id]
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

        public void Add(Player player)
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
