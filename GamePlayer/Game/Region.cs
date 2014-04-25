using System;
using System.Collections.Generic;
using System.Linq;
using GamePlayer.Infrastructure;

namespace GamePlayer.Game
{
    public class Region : IUniqueId
    {
        public int Id { get; private set; }

        public SuperRegion SuperRegion { get; private set; }

        public Player Owner { get; set; }
        public int Armies { get; set; }
        public int MaxAttackTransfer { get { return Armies - GameSettings.MinimumArmies; } }
        public bool IsVisible { get; set; }

        public readonly Regions Neighbors = new Regions();

        public bool IsBorderRegion
        {
            get
            {
                return Convert.ToBoolean(Neighbors.Count(n => n.SuperRegion != SuperRegion));
            }
        }

        public Region(int id, SuperRegion superRegion)
        {
            Id = id;
            
            SuperRegion = superRegion;
            
            superRegion.Regions.Add(this);
        }

        public int BoardingEnemyArmies
        {
            get { return (BoardingEnemies.Sum(r => r.Armies)); }
        }

        public IEnumerable<Region> BoardingEnemies
        {
            get { return (Neighbors.Where(r => r.Owner != Owner && r.Owner != null && !r.Owner.Friendly)); }
        }

        public IEnumerable<Region> BoardingNeutral
        {
            get { return (Neighbors.Where(r => r.Owner == null)); }
        }

        public IEnumerable<Region> BoardingUncontrolled
        {
            get { return (BoardingEnemies.Union(BoardingNeutral)); }
        }

        public IEnumerable<SuperRegion> BoardingSuperRegions
        {
            get { return (Neighbors.Select(r => r.SuperRegion).Distinct()); }
        }
    }
}
