using GamePlayer.Game;

namespace GamePlayer.Botting
{
    public class AttackTransfer
    {
        public Region Source { get; private set; }
        public Region Target { get; private set; }
        public int Armies { get; private set; }

        public AttackTransfer(Region source, Region target, int armies)
        {
            Source = source;
            Target = target;
            Armies = armies;
        }
    }
}
