using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketbolIstatik.Models
{
    public class HomeTeamStats : HomePlayer
    {
       public decimal HomeTotalScore { get { return (Total3ptCount * 3) + (Total2ptCount * 2) + TotalFtCount; } }

        public decimal Total3ptCount { get { return PlayerListHome.Sum(x => x.ThreePtMadeCount); } }
        public decimal Total2ptCount { get { return PlayerListHome.Sum(x => x.TwoPtMadeCount); } }
        public decimal TotalFtCount { get { return PlayerListHome.Sum(x => x.FreeThrowMadeCount); } }
        public decimal Total3ptAttempt { get { return PlayerListHome.Sum(x => x.ThreePtTryCount); } }
        public decimal Total2ptAttempt { get { return PlayerListHome.Sum(x => x.TwoPtTryCount); } }
        public decimal TotalFtAttempt { get { return PlayerListHome.Sum(x => x.FreeThrowTryCount); } }

        public string TotalTwoPointPercentage { get { return $"{TotalTwoPointPer()} %"; } }
        public decimal TotalTwoPointPer()
        {
            if (Total2ptAttempt != 0)
                return Math.Round((100 * Total2ptCount / Total2ptAttempt), 1);
            else
                return 0;
            
        }

        public string TotalThreePointPercentage { get { return $"{TotalThreePointPer()} %"; } }
        public decimal TotalThreePointPer()
        {
            if (Total3ptAttempt != 0)
                return Math.Round((100 * Total3ptCount / Total3ptAttempt), 1);
            else
                return 0;
        }

        public string TotalFtPointPercentage { get { return $"{TotalFTPointPer()} %"; } }
        public decimal TotalFTPointPer()
        {
            if (TotalFtAttempt != 0)
                return Math.Round((100 * TotalFtCount / TotalFtAttempt), 1);
            else
                return 0;
        }
        public decimal TotalOffReb { get { return PlayerListHome.Sum(x => x.OffensiveReboundCount); } }
        public decimal TotalDefReb { get { return PlayerListHome.Sum(x => x.DefensiveReboundCount); } }
        public decimal TotalReb { get { return TotalOffReb+TotalDefReb; } }
        public decimal TotalAsist { get { return PlayerListHome.Sum(x => x.AsistCount); } }
        public decimal TotalSteal { get { return PlayerListHome.Sum(x => x.StealCount); } }
        public decimal TotalBlock { get { return PlayerListHome.Sum(x => x.BlockCount); } }
        public decimal TotalFoul { get { return PlayerListHome.Sum(x => x.FoulCount); } }
        public decimal TotalTurnover { get { return PlayerListHome.Sum(x => x.TO); } }

    }
}
