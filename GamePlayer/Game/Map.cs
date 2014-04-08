using System;
using System.Collections.Generic;

namespace GamePlayer.Game
{
    public class Map
    {
        public readonly SuperRegions SuperRegions;

        public readonly Regions Regions;
        public readonly Players Players;

        public Map()
        {
            SuperRegions = new SuperRegions();
            Regions = new Regions(SuperRegions);
            Players = new Players();
        }
    }
}
