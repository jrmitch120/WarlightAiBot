using System;
using System.Linq;

namespace GamePlayer.Game
{
    public class Region
    {
        public readonly int Id;
        public readonly Regions Neighbors = new Regions();

        public SuperRegion SuperRegion { get; private set; }
        public Player Owner { get; set; }
        public int Armies { get; set; }
        public bool IsVisible { get; set; }

        public bool IsBoarderRegion
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
    }
}
