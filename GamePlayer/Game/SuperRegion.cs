using System.Collections.Generic;
using System.Linq;

namespace GamePlayer.Game
{
    public class SuperRegion
    {
        public readonly Regions Regions = new Regions();

        public int Id { get; private set; }
        public int Bonus { get; set; }

        public IEnumerable<Region> BoarderRegions
        {
            get { return Regions.Where(r => r.IsBoarderRegion); }
        }

        public SuperRegion(int id, int bonus)
        {
            Id = id;
            Bonus = bonus;
        }
    }
}
