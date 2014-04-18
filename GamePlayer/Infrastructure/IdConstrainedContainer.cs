using System.Collections;
using System.Collections.Generic;

namespace GamePlayer.Infrastructure
{
    public class IdConstrainedContainer<T> : IEnumerable<T> where T : IUniqueId
    {
        private readonly Dictionary<int, T> _items = new Dictionary<int,T>();

        public int Count { get { return _items.Values.Count; } }

        public T this[int regionId]
        {
            get { return _items[regionId]; }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(T item)
        {
            _items.Add(item.Id, item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (T item in items)
                _items.Add(item.Id, item);
        }
    }
}
