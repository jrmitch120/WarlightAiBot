using System.Collections;
using System.Collections.Generic;

namespace GamePlayer.Game
{
    public class Regions : IEnumerable<Region>
    {
        private readonly Dictionary<int, Region> _regions = new Dictionary<int,Region>();

        public int Count { get { return _regions.Values.Count; } }

        public Region this[int regionId]
        {
            get { return _regions[regionId]; }
        }

        public IEnumerator<Region> GetEnumerator()
        {
            return _regions.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Region region)
        {
            if (_regions.ContainsKey(region.Id))
                throw new GameException("Region already exists");

            _regions.Add(region.Id, region);
        }
    }
}
