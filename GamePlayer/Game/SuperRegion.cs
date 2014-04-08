using System.Collections.Generic;

namespace GamePlayer.Game
{
    public class SuperRegion
    {
        public int Id { get; private set; }
        public int BonusArmies { get; private set; }

        public readonly Regions Regions;

        public Player Owner { get; set; }

        public SuperRegion(int id, int bonusArmies)
        {
            Id = id;
            BonusArmies = bonusArmies;

            // Regions can only be added to this SuperRegion here.
            var superRegion = new SuperRegions();
            superRegion.AddSuperRegion(this);
            Regions = new Regions(superRegion);
        }
    }
}
