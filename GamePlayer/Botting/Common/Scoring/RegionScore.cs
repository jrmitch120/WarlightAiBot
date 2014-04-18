using GamePlayer.Game;

namespace GamePlayer.Botting.Common.Scoring
{
    public class RegionScore<T> where T : class, IScoring
    {
        public readonly T Scores;

        public Region Region { get; private set; }

        public RegionScore(Region region, T scores)
        {
            Region = region;
            Scores = scores;
        }
    }
}