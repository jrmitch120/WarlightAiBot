namespace GamePlayer.Botting.Common.Scoring
{
    public class StartRegion : IScoring
    {
        public double CumulativeScore
        {
            get { return (SuperRegionScore + DefensibilityScore + BorderRegionScore + ChokepointScore); }
        }
        /// <summary>
        /// How important does the region figure to be in controlling the SuperRegion
        /// </summary>
        public double SuperRegionScore { get; set; }
        
        /// <summary>
        /// How defensible the region is
        /// </summary>
        public double DefensibilityScore { get; set; }
        
        /// <summary>
        /// Does the region make up part of the border of a SuperRegion
        /// </summary>
        public double BorderRegionScore { get; set; }
        
        /// <summary>
        /// How vital the region is in reguards to allowing access to the SuperRegion
        /// </summary>
        public double ChokepointScore { get; set; }
    }
}