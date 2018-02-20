using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasketbolIstatik
{
    public class Player
    {
        //Oyuncu listeleri oluşturduk.
        public static List<Player> PlayerList = new List<Player>();
        public static List<AwayPlayer> PlayerListAway = new List<AwayPlayer>();
        public static List<HomePlayer> PlayerListHome = new List<HomePlayer>();
        //Sayaç değerlerini genelde tanımladık.
        public decimal TwoPtTryCount = 0, TwoPtMadeCount = 0, ThreePtMadeCount = 0, ThreePtTryCount = 0, FreeThrowMadeCount = 0, FreeThrowTryCount = 0, OffensiveReboundCount = 0, DefensiveReboundCount = 0, AsistCount = 0, BlockCount = 0, StealCount = 0, FoulCount = 0, Rebound=0, TO=0;
        decimal t3ptper,t2ptper,ftper;
        public string PlayerName { get; set; }
        public string No { get; set; }
        public string TeamName { get; set; }
        public decimal TotalPlayerScore { get {return TwoPtMadeCount*2+ThreePtMadeCount*3+FreeThrowMadeCount ; } }

        //2 sayılık atışların görünümü
        public decimal TwoPointMadeView
        {
            get { return TwoPtMadeCount; }
        }
        public void TwoPointMade()
        {
            TwoPtMadeCount++;
            TwoPtTryCount++;
        }
        
        public decimal TwoPointFalseView
        {
            get { return TwoPtTryCount; }
        }
        public void TwoPointFalse()
        {
            TwoPtTryCount++;
        }


        public string TwoPointPercentage { get { return String.Format("{0:0.0}%", t2ptper); } }
        public void TwoPointPer()
        {
            if (TwoPtTryCount > 0)
            {
                t2ptper = 100 * TwoPtMadeCount / TwoPtTryCount;
            }
            else
            {
                t2ptper = 0;
            }
           
        }
        //3 sayılık atışların görünümü
        public decimal ThreePointMadeView
        {
            get { return ThreePtMadeCount; }
        }
        public void ThreePointMade()
        {
            ThreePtMadeCount++;
            ThreePtTryCount++;
        }
        public decimal ThreePointFalseView
        {
            get { return ThreePtTryCount; }
        }
        
        public string ThreePointPercentage { get { return String.Format("{0:0.0}%", t3ptper); } }
        public void ThreePointPer()
        {
            if (ThreePtTryCount > 0)
            {
                t3ptper = 100 * ThreePtMadeCount / ThreePtTryCount;
            }
            else
            {
                t3ptper = 0;
            }
            
        }
        
        public void ThreePointFalse()
        {
            ThreePtTryCount++;
        }

        //Serbest atışların görünümü
        public decimal FreeThrowPointMadeView
        {
            get { return FreeThrowMadeCount; }
        }
        public void FreeThrowMade()
        {
            FreeThrowMadeCount++;
            FreeThrowTryCount++;
        }
        public decimal FreeThrowPointFalseView
        {
            get { return FreeThrowTryCount; }
        }
        public void FreeThrowFalse()
        {
            FreeThrowTryCount++;
        }
        public string FTPointPercentage { get { return String.Format("{0:0.0}%", ftper); } }
        public void FTPointPer()
        {
            if (FreeThrowTryCount > 0)
            {
                ftper = 100 * FreeThrowMadeCount / FreeThrowTryCount;
            }
            else
            {
                ftper = 0;
            }
            
        }

        //Offensive Rebound
        public string OffensiveReboundView
        {
            get { return $"{OffensiveReboundCount}"; }
        }
        public void OffReb()
        {
            OffensiveReboundCount++;
        }

        //Defensive Rebound
        public string DefensiveReboundView
        {
            get { return $"{DefensiveReboundCount}"; }
        }
        public void DefReb()
        {
            DefensiveReboundCount++;
        }
        public string Reb { get { return $"{(OffensiveReboundCount + DefensiveReboundCount)}"; } }
       
        //Asist
        public string AsistView
        {
            get { return $"{AsistCount}"; }
        }
        public void Asist()
        {
            AsistCount++;
        }
        //Steal
        public string StealView
        {
            get { return $"{StealCount}"; }
        }
        public void Steal()
        {
            StealCount++;
        }
        //Turnover
        public string TOView
        {
            get { return $"{TO}"; }
        }
        public void Turnover()
        {
            TO++;
        }
        //Block
        public string BlockView
        {
            get { return $"{BlockCount}"; }
        }
        public void Block()
        {
            BlockCount++;
        }
        //Foul
        public string FoulView
        {
            get { return $"{FoulCount}"; }
        }
        public void Foul()
        {
            FoulCount++;
        }

        //Hataları Düzeltme Metodları
        #region Hatalı Giriş Metodları
        public void TwoPointReduce()
        {
            TwoPtMadeCount--;
            TwoPtTryCount--;
        }
        public void TwoPointTryReduce()
        {
            TwoPtTryCount--;
        }

        public void ThreePointReduce()
        {
            ThreePtMadeCount--;
            ThreePtTryCount--;
        }
        public void ThreePointTRYReduce()
        {
            ThreePtTryCount--;
        }
        public void FTPointReduce()
        {
            FreeThrowMadeCount--;
            FreeThrowTryCount--;
        }
        public void FTPointTryReduce()
        {
            FreeThrowTryCount--;
        }
        public void OffRebReduce()
        {
            OffensiveReboundCount--;
        }
        public void DefRebReduce()
        {
            DefensiveReboundCount--;
        }
        public void AsistReduce()
        {
            AsistCount--;
        }
        public void StealReduce()
        {
            StealCount--;
        }
        public void BlockReduce()
        {
            BlockCount--;
        }
        public void FoulReduce()
        {
            FoulCount--;
        }
        public void TOReduce()
        {
            TO--;
        }
        #endregion

        public TimeSpan zaman { get; set; }
        public bool SahadaMi { get; set; }
    }
}
