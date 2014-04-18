using System.Collections.Generic;
using System.Linq;
using GamePlayer.Infrastructure;

namespace GamePlayer.Game
{
    public class SuperRegion : IUniqueId
    {
        public int Id { get; private set; }
        public int Bonus { get; private set; }

        public readonly Regions Regions = new Regions();

        public IEnumerable<Region> BorderRegions
        {
            get { return Regions.Where(r => r.IsBorderRegion); }
        }

        public SuperRegion(int id, int bonus)
        {
            Id = id;
            Bonus = bonus;
        }
    }
}
