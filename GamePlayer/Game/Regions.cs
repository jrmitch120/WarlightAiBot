using System.Collections.Generic;
using System.Linq;
using GamePlayer.Infrastructure;

namespace GamePlayer.Game
{
    public class Regions : IdConstrainedContainer<Region>
    {
        public IEnumerable<Region> OwnedBy(Player player)
        {
            return (this.Where(p => p.Owner == player));
        }
    }
}
