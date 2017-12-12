using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketbolIstatik.ViewModels
{
    public class StatsView
    {
        public string NO { get; set; }
        public string NAME { get; set; }
        public TimeSpan MIN { get; set; }
        public decimal PTS { get; set; }
        public string REB { get; set; }
        public string AST { get; set; }
        public string STL { get; set; }
        public string BLK { get; set; }

        [DisplayName("2PTM")]
        public decimal FGM { get; set; }
        [DisplayName("2PTA")]
        public decimal FGA { get; set; }
        [DisplayName("2PT%")]
        public string FG2Per { get; set; }
        [DisplayName("3PTM")]
        public decimal FG3M { get; set; }
        [DisplayName("3PTA")]
        public decimal FG3A { get; set; }
        [DisplayName("3PT%")]
        public string FG3Per { get; set; }

        [DisplayName("FTM")]
        public decimal FTM { get; set; }
        [DisplayName("FTA")]
        public decimal FTA { get; set; }
        [DisplayName("FT%")]
        public string FT2Per { get; set; }

        public string OREB { get; set;}
        public string DREB { get; set; }
        public string TOV { get; set; }
        public string FOUL { get; set; }

    }
}
