using System.Collections.Generic;
using System.Linq;
using GamePlayer.Infrastructure;

namespace GamePlayer.Game
{
    public class Regions : IdConstrainedContainer<Region>
    {
        public IEnumerable<Region> OwnedBy(Player player)
        {
            return (this.Where(r => r.Owner == player));
        }

        /// <summary>
        /// Breadth first search to find the shortest path between regions
        /// </summary>
        /// <param name="starting">Starting region</param>
        /// <param name="destination">Destination region</param>
        /// <param name="controlledBy">Optional player that must control all regions in the path</param>
        /// <returns>Direct path from starting to deistination, if possible</returns>
        public IEnumerable<Region> ShortestPath(Region starting, Region destination, Player controlledBy = null)
        {
            var q = new Queue<Region>();
            var path = new List<Region>();

            // key = visited region, value = region that found it.  Region that found it is required to 
            // compute the shortest path.
            var visited = new Dictionary<Region, Region>();

            q.Enqueue(starting);
            
            while (q.Count > 0)
            {
                var regionVertex = q.Dequeue();

                foreach (
                    Region neighbor in
                        regionVertex.Neighbors.Where(r => controlledBy == null || r.Owner == controlledBy))
                {
                    if (!visited.ContainsKey(neighbor))
                    {
                        visited.Add(neighbor, regionVertex);
                        q.Enqueue(neighbor);
                    }
                }
            }

            // Compuete the shortest path.
            if (visited.ContainsKey(destination))
            {
                Region node = destination;

                while (node != starting)
                {
                    path.Insert(0,node);
                    node = visited[node];
                }
            }
            // else unreachable

            return path;
        }
        
    }
}
