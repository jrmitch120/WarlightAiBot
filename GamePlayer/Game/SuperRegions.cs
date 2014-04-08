using System;
using System.Collections;
using System.Collections.Generic;

namespace GamePlayer.Game
{
    public class SuperRegions : IEnumerable<SuperRegion>
    {
        private readonly IDictionary<int, SuperRegion> _superRegions;

        public SuperRegions()
        {
            _superRegions = new Dictionary<int, SuperRegion>();
        }

        public SuperRegion this[int id]
        {
            get
            {
                try
                {
                    return _superRegions[id];
                }
                catch (KeyNotFoundException ex)
                {
                    throw new GameException("SuperRegion does not exist", ex);
                }
            }
        }

        public void AddSuperRegion(SuperRegion superRegion)
        {
            try
            {
                _superRegions.Add(superRegion.Id, superRegion);
            }
            catch (ArgumentException ex)
            {
                throw new GameException("SuperRegion already exists");
            }
        }

        public IEnumerator<SuperRegion> GetEnumerator()
        {
            return _superRegions.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
