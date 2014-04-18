using System;
using System.Collections.Generic;
using GamePlayer.Botting.Common.Scoring;
using GamePlayer.Game;
using System.Linq;

namespace GamePlayer.Botting.CptnCompetent
{
    public class CptnCompetentBot : Bot, IBot
    {
        private readonly IScoresCalculator _calc;

        public CptnCompetentBot()
        {
            _calc = new StandardCalculator();
        }

        public IEnumerable<AttackTransfer> AttackTransfer(Map map)
        {
            throw new NotImplementedException();
        }

        public Regions PickStartingRegions(Map map, Regions availableOptions)
        {
            int numberToPick = availableOptions.Count > 6 ? 6 : availableOptions.Count;

            IEnumerable<RegionScore<StartRegion>> scores = _calc.CalculateStartRegions(map);

            var pickList = new Regions();

            pickList.AddRange(scores
                .OrderByCumulativeScore()
                .Select(r => r.Region)
                .Take(numberToPick));

            return pickList;
        }

        public IEnumerable<ArmyPlacement> PlaceArmies(Map map)
        {
            throw new NotImplementedException();
        }
    }
}
