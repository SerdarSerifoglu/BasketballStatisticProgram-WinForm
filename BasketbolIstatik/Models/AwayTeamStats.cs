using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketbolIstatik.Models
{
    public class AwayTeamStats : AwayPlayer
    {
        public decimal AwayScore { get { return (ATotal3ptCount * 3) + (ATotal2ptCount * 2) + ATotalFtCount; } }
        public decimal ATotal3ptCount { get { return PlayerListAway.Sum(x => x.ThreePtMadeCount); } }
        public decimal ATotal2ptCount { get { return PlayerListAway.Sum(x => x.TwoPtMadeCount); } }
        public decimal ATotalFtCount { get { return PlayerListAway.Sum(x => x.FreeThrowMadeCount); } }
        public decimal ATotal3ptAttempt { get { return PlayerListAway.Sum(x => x.ThreePtTryCount); } }
        public decimal ATotal2ptAttempt { get { return PlayerListAway.Sum(x => x.TwoPtTryCount); } }
        public decimal ATotalFtAttempt { get { return PlayerListAway.Sum(x => x.FreeThrowTryCount); } }
                       
        public string  ATotalTwoPointPercentage { get { return $"{ATotalTwoPointPer()} %"; } }
        public decimal ATotalTwoPointPer()
        {
            if (ATotal2ptAttempt != 0)
                return Math.Round((100 * ATotal2ptCount / ATotal2ptAttempt), 1);
            else
                return 0;
        }

        public string  ATotalThreePointPercentage { get { return $"{ATotalThreePointPer()} %"; } }
        public decimal ATotalThreePointPer()
        {
            if (ATotal3ptAttempt != 0)
                return Math.Round((100 * ATotal3ptCount / ATotal3ptAttempt), 1);
            else
                return 0;
        }

        public string  ATotalFtPointPercentage { get { return $"{ATotalFTPointPer()} %"; } }
        public decimal ATotalFTPointPer()
        {
            if (ATotalFtAttempt != 0)
                return Math.Round((100 * ATotalFtCount / ATotalFtAttempt), 1);
            else
                return 0;
        }
        public decimal ATotalOffReb { get { return PlayerListAway.Sum(x => x.OffensiveReboundCount); } }
        public decimal ATotalDefReb { get { return PlayerListAway.Sum(x => x.DefensiveReboundCount); } }
        public decimal ATotalReb { get { return ATotalOffReb + ATotalDefReb; } }
        public decimal ATotalAsist { get { return PlayerListAway.Sum(x => x.AsistCount); } }
        public decimal ATotalSteal { get { return PlayerListAway.Sum(x => x.StealCount); } }
        public decimal ATotalBlock { get { return PlayerListAway.Sum(x => x.BlockCount); } }
        public decimal ATotalFoul { get { return PlayerListAway.Sum(x => x.FoulCount); } }
        public decimal ATotalTurnover { get { return PlayerListAway.Sum(x => x.TO); } }

    }
}
