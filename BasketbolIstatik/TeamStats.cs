using BasketbolIstatik.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasketbolIstatik
{
    public partial class TeamStats : Form
    {
        public TeamStats()
        {
            InitializeComponent();
        }
        HomeTeamStats ts = new HomeTeamStats();
        AwayTeamStats ats = new AwayTeamStats();
        private void TeamStats_Load(object sender, EventArgs e)
        {
            //StatisticView sw = new StatisticView();
            //label1.Text = sw.label4.Text;
            //label3.Text = sw.label5.Text;
            label6.Text = ts.HomeTotalScore + "-" + ats.AwayScore;
            //Home Team Labels
            H2pt.Text = $"{ts.Total2ptCount} / {ts.Total2ptAttempt}";
            H3pt.Text= $"{ts.Total3ptCount} / {ts.Total3ptAttempt}";
            HFt.Text= $"{ts.TotalFtCount} / {ts.TotalFtAttempt}";

            H2ptP.Text = ts.TotalTwoPointPercentage;
            H3ptP.Text = ts.TotalThreePointPercentage;
            HFtP.Text = ts.TotalFtPointPercentage;

            HOffreb.Text = ts.TotalOffReb.ToString();
            Hdefreb.Text = ts.TotalDefReb.ToString();
            Htreb.Text = ts.TotalReb.ToString();
            hasist.Text=ts.TotalAsist.ToString();
            hsteal.Text=ts.TotalSteal.ToString();
            hblock.Text=ts.TotalBlock.ToString();
            hfoul.Text=ts.TotalFoul.ToString();
            Hto.Text=ts.TotalTurnover.ToString();


            //Away Team Labels
            A2pt.Text = $"{ ats.ATotal2ptCount} / { ats.ATotal2ptAttempt}";
            A3pt.Text= $"{ ats.ATotal3ptCount} / { ats.ATotal3ptAttempt}";
            AFt.Text= $"{ ats.ATotalFtCount} / { ats.ATotalFtAttempt}";

            A2ptP.Text = ats.ATotalTwoPointPercentage;
            A3ptP.Text = ats.ATotalThreePointPercentage;
            AftP.Text = ats.ATotalFtPointPercentage;

            AOffreb.Text = ats.ATotalOffReb.ToString();
            Adefrib.Text=ats.ATotalDefReb.ToString();
            Atreb.Text=ats.ATotalReb.ToString();
            Aasist.Text=ats.ATotalAsist.ToString();
            Asteal.Text=ats.ATotalSteal.ToString();
            Ablock.Text=ats.ATotalBlock.ToString();
            Afoul.Text=ats.ATotalFoul.ToString();
            Ato.Text=ats.ATotalTurnover.ToString();







        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
