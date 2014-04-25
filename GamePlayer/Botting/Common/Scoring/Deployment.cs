namespace GamePlayer.Botting.Common.Scoring
{
    public class Deployment : IScoring
    {
        public double CumulativeScore
        {
            get { return HostilityScore + ExpansionScore + SuperRegionScore; }
        }

        /// <summary>
        /// How hot a region is in terms of invading 
        /// </summary>
        public double HostilityScore { get; set; }

        /// <summary>
        /// Can we expand from here to control more of the board?
        /// </summary>
        public double ExpansionScore { get; set; }

        /// <summary>
        /// Score based on number of region left to capture a region's SuperRegion
        /// </summary>
        public double SuperRegionScore { get; set; }
    }
}