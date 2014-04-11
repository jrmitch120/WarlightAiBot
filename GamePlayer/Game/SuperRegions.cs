using System.Collections;
using System.Collections.Generic;

namespace GamePlayer.Game
{
    public class SuperRegions : IEnumerable<SuperRegion>
    {
        private readonly Dictionary<int, SuperRegion> _superRegions = new Dictionary<int,SuperRegion>();

        public int Count { get { return _superRegions.Values.Count; } }

        public SuperRegion this[int superRegionId]
        {
            get { return _superRegions[superRegionId]; }
        }

        public IEnumerator<SuperRegion> GetEnumerator()
        {
            return _superRegions.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(SuperRegion superRegion)
        {
            if (_superRegions.ContainsKey(superRegion.Id))
                throw new GameException("SuperRegion already exists");

            _superRegions.Add(superRegion.Id, superRegion);
        }
    }
}
