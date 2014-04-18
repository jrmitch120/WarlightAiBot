namespace GamePlayer.Botting.Common.Scoring
{
    public class Deployment : IScoring
    {
        public double CumulativeScore
        {
            get { return HostilityScore; }
        }

        /// <summary>
        /// How hot a region is in terms of invading 
        /// </summary>
        public double HostilityScore { get; set; }

        /// <summary>
        /// How important it is to retain this region
        /// </summary>
        public double ImporanceScore { get; set; }

        /// <summary>
        /// Can we expand from here to control more of the board?
        /// </summary>
        public double ExpansionScore { get; set; }
    }
}