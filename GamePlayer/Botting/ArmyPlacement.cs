using GamePlayer.Game;
using GamePlayer.Infrastructure;

namespace GamePlayer.Botting
{
    public class ArmyPlacement : IUniqueId
    {
        public int Id 
        {
            get { return Region.Id; }
        }

        public Region Region { get; private set; }
        public int Armies { get; private set; }

        public ArmyPlacement(Region region, int armies)
        {
            Region = region;
            Armies = armies;
        }
    }
}
