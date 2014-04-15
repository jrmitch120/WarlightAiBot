using System.Collections;
using System.Collections.Generic;

namespace GamePlayer.Infrastructure
{
    public class IdConstrainedContainer<T> : IEnumerable<T> where T : IUniqueId
    {
        private readonly Dictionary<int, T> _regions = new Dictionary<int,T>();

        public int Count { get { return _regions.Values.Count; } }

        public T this[int regionId]
        {
            get { return _regions[regionId]; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _regions.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            _regions.Add(item.Id, item);
        }
    }
}
