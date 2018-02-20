using BasketbolIstatik.Models;
using BasketbolIstatik.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;



namespace BasketbolIstatik
{
    public partial class StatisticView : Form
    {
        public StatisticView()
        {
            InitializeComponent();
        }
        HomePlayer SelectPlayerHome;
        AwayPlayer SelectPlayerAway;

        //StatsView modele değerleri tanımlıyoruz.
        public List<StatsView> HomeStatsView()
        {
            return HomePlayer.PlayerListHome.Select(x => new StatsView()
            {
                NO = x.No,
                NAME = x.PlayerName,
                MIN = x.zaman,
                PTS = x.TotalPlayerScore,
                REB = x.Reb,
                AST = x.AsistView,
                STL = x.StealView,
                BLK = x.BlockView,
                FGM = x.TwoPointMadeView,
                FGA = x.TwoPointFalseView,
                FG2Per = x.TwoPointPercentage,
                FG3M = x.ThreePointMadeView,
                FG3A = x.ThreePointFalseView,
                FG3Per = x.ThreePointPercentage,
                FTM = x.FreeThrowPointMadeView,
                FTA = x.FreeThrowPointFalseView,
                FT2Per = x.FTPointPercentage,
                OREB = x.OffensiveReboundView,
                DREB = x.DefensiveReboundView,
                TOV = x.TOView,
                FOUL = x.FoulView

            }).ToList();
        }

        public List<StatsView> AwayStatsView()
        {
            return HomePlayer.PlayerListAway.Select(x => new StatsView()
            {
                NO = x.No,
                NAME = x.PlayerName,
                MIN = x.zaman,
                PTS = x.TotalPlayerScore,
                REB = x.Reb,
                AST = x.AsistView,
                STL = x.StealView,
                BLK = x.BlockView,
                FGM = x.TwoPointMadeView,
                FGA = x.TwoPointFalseView,
                FG2Per = x.TwoPointPercentage,
                FG3M = x.ThreePointMadeView,
                FG3A = x.ThreePointFalseView,
                FG3Per = x.ThreePointPercentage,
                FTM = x.FreeThrowPointMadeView,
                FTA = x.FreeThrowPointFalseView,
                FT2Per = x.FTPointPercentage,
                OREB = x.OffensiveReboundView,
                DREB = x.DefensiveReboundView,
                TOV = x.TOView,
                FOUL = x.FoulView
            }).ToList();
        }
        

        //DataGridView'ların Refresh Metodları
        public void DataGridView1Refresh()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = HomeStatsView();
        }
        public void DataGridView2Refresh()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = AwayStatsView();
        }

        //Seçili takımların oyuncu listelerinin .json uzantılı dosyalardan okunması
        public void LoadComboBox1()
        {
            JavaScriptSerializer tercuman = new JavaScriptSerializer();
            string dosyaAdi = comboBox1.Text + ".json";
            if (File.Exists(dosyaAdi))
            {
                try
                {
                    string okunan = File.ReadAllText(dosyaAdi);
                    HomePlayer.PlayerListHome = tercuman.Deserialize<List<HomePlayer>>(okunan);
                }
                catch { }
            }
        }
        public void LoadComboBox2()
        {
            JavaScriptSerializer tercuman = new JavaScriptSerializer();
            string dosyaAdi = comboBox2.Text + ".json";
            if (File.Exists(dosyaAdi))
            {
                try
                {
                    string okunan = File.ReadAllText(dosyaAdi);
                    AwayPlayer.PlayerListAway = tercuman.Deserialize<List<AwayPlayer>>(okunan);
                }
                catch { }
            }
        }
        public decimal HomeScore;
        public decimal AwayScore;
        //Scoreboard güncelleme metodları
        public void HomeScoreboardUpdate()
        {
            HomeTeamStats hts = new HomeTeamStats();
            label2.Text = hts.HomeTotalScore.ToString();
        }
        public void AwayScoreboardUpdate()
        {
            AwayTeamStats ats = new AwayTeamStats();
            label3.Text = ats.AwayScore.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnDeleteH.Enabled = false;
            btnDeleteA.Enabled = false;
            panelHomeButtons.Enabled = false;
            panelHomeReduce.Visible = false;
            panelAwayButtons.Enabled = false;
            panelAwayReduce.Visible = false;
            label6.Text = "1-Q";
            btnPlayerChanged.Enabled = false;
            btn2PlayerChanged.Enabled = false;
            TimerStartStop.Text = "Start";
            btnPlayerChanged.BackColor = Color.Red;
            btn2PlayerChanged.BackColor = Color.Red;
            DirectoryInfo fileInfo = new DirectoryInfo(Environment.CurrentDirectory);

            foreach (FileInfo item in fileInfo.GetFiles("*.json"))
            {
                comboBox1.Items.Add(item.Name.Replace(".json", ""));
                comboBox2.Items.Add(item.Name.Replace(".json", ""));
            }
        }
        //Alt köşelerdeki oyuncu istatistiklerini yazdıran metodlar
        public void HomePlayerShortInfo()
        {
            lblADNO.Text = SelectPlayerHome.No + "# " + SelectPlayerHome.PlayerName;
            lblAST.Text = "AST: " + SelectPlayerHome.AsistView;
            lblFO.Text = "Foul: " + SelectPlayerHome.FoulView;
            lblPTS.Text = "PTS: " + SelectPlayerHome.TotalPlayerScore.ToString();
            lblREB.Text = "REB: " + SelectPlayerHome.Reb.ToString();
            lblSTL.Text = "STL: " + SelectPlayerHome.StealView;
            lblTO.Text = "TO: " + SelectPlayerHome.TOView;
            lblBLK.Text = "BLK: " + SelectPlayerHome.BlockView;
        }

        public void AwayPlayerShortInfo()
        {
            lblADNOA.Text = SelectPlayerAway.No + "# " + SelectPlayerAway.PlayerName;
            lblASTA.Text = "AST: " + SelectPlayerAway.AsistView;
            lblFOULA.Text = "Foul: " + SelectPlayerAway.FoulView;
            lblPTSA.Text = "PTS: " + SelectPlayerAway.TotalPlayerScore.ToString();
            lblREBA.Text = "REB: " + SelectPlayerAway.Reb.ToString();
            lblSTLA.Text = "STL: " + SelectPlayerAway.StealView;
            lblTOA.Text = "TO: " + SelectPlayerAway.TOView;
            lblBLKA.Text = "BLK: " + SelectPlayerAway.BlockView;
        }
        //Ev sahibi takım oyuncularının buttonları
        #region Form HomePlayer Buttons

        private void TabControlSelectHome()
        {
            tabControl1.SelectedTab = tabControl1.TabPages[0];
            tabControl2.SelectedTab = tabControl2.TabPages[0];
        }

        private void btn2PTMade_Click(object sender, EventArgs e)
        {

            TabControlSelectHome();
            SelectPlayerHome.TwoPointMade();
            SelectPlayerHome.TwoPointPer();
            DataGridView1Refresh();
            HomeScoreboardUpdate();
            HomePlayerShortInfo();
            listBox1.Items.Add($"<{label1.Text}> {SelectPlayerHome.PlayerName} 2PT Shot: Made ({label2.Text}-{label3.Text})");
        }

        private void btn2PTAttempt_Click(object sender, EventArgs e)
        {
            TabControlSelectHome();
            SelectPlayerHome.TwoPointFalse();
            SelectPlayerHome.TwoPointPer();
            DataGridView1Refresh();
            listBox1.Items.Add($"<{label1.Text}> {SelectPlayerHome.PlayerName} 2PT Shot: Missed");
        }

        private void btn3PTMade_Click(object sender, EventArgs e)
        {

            TabControlSelectHome();
            SelectPlayerHome.ThreePointMade();
            SelectPlayerHome.ThreePointPer();
            DataGridView1Refresh();
            HomeScoreboardUpdate();
            HomePlayerShortInfo();
            listBox1.Items.Add($"<{label1.Text}> {SelectPlayerHome.PlayerName} 3PT Shot: Made ({label2.Text}-{label3.Text}) ");
        }

        private void btn3PTAttempt_Click(object sender, EventArgs e)
        {
            TabControlSelectHome();
            SelectPlayerHome.ThreePointFalse();
            SelectPlayerHome.ThreePointPer();
            DataGridView1Refresh();
            listBox1.Items.Add($"<{label1.Text}> {SelectPlayerHome.PlayerName} 3PT Shot: Missed");
        }

        private void btnFTMade_Click(object sender, EventArgs e)
        {

            TabControlSelectHome();
            SelectPlayerHome.FreeThrowMade();
            SelectPlayerHome.FTPointPer();
            DataGridView1Refresh();
            HomeScoreboardUpdate();
            HomePlayerShortInfo();
            listBox1.Items.Add($"<{label1.Text}> {SelectPlayerHome.PlayerName} FT: Made ({label2.Text}-{label3.Text}) ");
        }

        private void btnFTAttempt_Click(object sender, EventArgs e)
        {
            TabControlSelectHome();
            SelectPlayerHome.FreeThrowFalse();
            SelectPlayerHome.FTPointPer();
            DataGridView1Refresh();
            listBox1.Items.Add($"<{label1.Text}> {SelectPlayerHome.PlayerName} FT: Missed");
        }
        private void btnDefReb_Click(object sender, EventArgs e)
        {
            SelectPlayerHome.DefReb();
            DataGridView1Refresh();
            HomePlayerShortInfo();
            listBox1.Items.Add($"<{label1.Text}> {SelectPlayerHome.PlayerName} Defensive Rebound");
        }
        private void btnOffReb_Click(object sender, EventArgs e)
        {
            SelectPlayerHome.OffReb();
            DataGridView1Refresh();
            HomePlayerShortInfo();
            listBox1.Items.Add($"<{label1.Text}> {SelectPlayerHome.PlayerName} Offensive Rebound");
        }

        private void btnAsist_Click(object sender, EventArgs e)
        {
            SelectPlayerHome.Asist();
            DataGridView1Refresh();
            HomePlayerShortInfo();
            listBox1.Items.Add($"<{label1.Text}> {SelectPlayerHome.PlayerName} Asist");
        }

        private void btnSteal_Click(object sender, EventArgs e)
        {
            SelectPlayerHome.Steal();
            DataGridView1Refresh();
            HomePlayerShortInfo();
            listBox1.Items.Add($"<{label1.Text}> {SelectPlayerHome.PlayerName} Steal");
        }

        private void btnTO_Click(object sender, EventArgs e)
        {
            SelectPlayerHome.Turnover();
            DataGridView1Refresh();
            HomePlayerShortInfo();
            listBox1.Items.Add($"<{label1.Text}> {SelectPlayerHome.PlayerName} Turnover");
        }

        private void btnBlock_Click(object sender, EventArgs e)
        {
            SelectPlayerHome.Block();
            DataGridView1Refresh();
            HomePlayerShortInfo();
            listBox1.Items.Add($"<{label1.Text}> {SelectPlayerHome.PlayerName} Block");
        }

        private void btnFoul_Click(object sender, EventArgs e)
        {
            SelectPlayerHome.Foul();
            DataGridView1Refresh();
            HomePlayerShortInfo();
            listBox1.Items.Add($"<{label1.Text}> {SelectPlayerHome.PlayerName} Foul");
        }
        #endregion
        //Deplasman sahibi takım oyuncularının buttonları
        #region Form AwayPlayer Buttons

        private void TabControlSelectAway()
        {
            tabControl1.SelectedTab = tabControl1.TabPages[1];
            tabControl2.SelectedTab = tabControl2.TabPages[1];
        }

        private void btn2PTMade2_Click(object sender, EventArgs e)
        {
            TabControlSelectAway();
            SelectPlayerAway.TwoPointMade();
            SelectPlayerAway.TwoPointPer();
            DataGridView2Refresh();
            AwayScoreboardUpdate();
            AwayPlayerShortInfo();
            listBox2.Items.Add($"<{label1.Text}> {SelectPlayerAway.PlayerName} 2PT Shot: Made ({label2.Text}-{label3.Text})");

        }

        private void btn2PTAttempt2_Click(object sender, EventArgs e)
        {
            TabControlSelectAway();
            SelectPlayerAway.TwoPointFalse();
            SelectPlayerAway.TwoPointPer();
            DataGridView2Refresh();
            listBox2.Items.Add($"<{label1.Text}> {SelectPlayerAway.PlayerName} 2PT Shot: Missed");
        }

        private void btn3PTMade2_Click(object sender, EventArgs e)
        {
            TabControlSelectAway();
            SelectPlayerAway.ThreePointMade();
            SelectPlayerAway.ThreePointPer();
            DataGridView2Refresh();
            AwayScoreboardUpdate();
            AwayPlayerShortInfo();
            listBox2.Items.Add($"<{label1.Text}> {SelectPlayerAway.PlayerName} 3PT Shot: Made ({label2.Text}-{label3.Text}) ");
        }

        private void btn3PTAttempt2_Click(object sender, EventArgs e)
        {
            TabControlSelectAway();
            SelectPlayerAway.ThreePointFalse();
            SelectPlayerAway.ThreePointPer();
            DataGridView2Refresh();
            listBox2.Items.Add($"<{label1.Text}> {SelectPlayerAway.PlayerName} 3PT Shot: Missed");
        }

        private void btnFTMade2_Click(object sender, EventArgs e)
        {
            TabControlSelectAway();
            SelectPlayerAway.FreeThrowMade();
            SelectPlayerAway.FTPointPer();
            DataGridView2Refresh();
            AwayScoreboardUpdate();
            AwayPlayerShortInfo();
            listBox2.Items.Add($"<{label1.Text}> {SelectPlayerAway.PlayerName} FT: Made ({label2.Text}-{label3.Text}) ");
        }

        private void btnFTAttempt2_Click(object sender, EventArgs e)
        {
            TabControlSelectAway();
            SelectPlayerAway.FreeThrowFalse();
            SelectPlayerAway.FTPointPer();
            DataGridView2Refresh();
            listBox2.Items.Add($"<{label1.Text}> {SelectPlayerAway.PlayerName} FT: Missed");
        }
        private void btnDefReb2_Click(object sender, EventArgs e)
        {
            SelectPlayerAway.DefReb();
            DataGridView2Refresh();
            AwayPlayerShortInfo();
            listBox2.Items.Add($"<{label1.Text}> {SelectPlayerAway.PlayerName} Defensive Rebound");
        }
        private void btnOffReb2_Click(object sender, EventArgs e)
        {
            SelectPlayerAway.OffReb();
            DataGridView2Refresh();
            AwayPlayerShortInfo();
            listBox2.Items.Add($"<{label1.Text}> {SelectPlayerAway.PlayerName} Offensive Rebound");
        }

        private void btnAsist2_Click(object sender, EventArgs e)
        {
            SelectPlayerAway.Asist();
            DataGridView2Refresh();
            AwayPlayerShortInfo();
            listBox2.Items.Add($"<{label1.Text}> {SelectPlayerAway.PlayerName} Asist");
        }
        private void btnTO2_Click(object sender, EventArgs e)
        {
            SelectPlayerAway.Turnover();
            DataGridView2Refresh();
            AwayPlayerShortInfo();
            listBox2.Items.Add($"<{label1.Text}> {SelectPlayerAway.PlayerName} Turnover");
        }
        private void btnSteal2_Click(object sender, EventArgs e)
        {
            SelectPlayerAway.Steal();
            DataGridView2Refresh();
            AwayPlayerShortInfo();
            listBox2.Items.Add($"<{label1.Text}> {SelectPlayerAway.PlayerName} Steal");
        }

        private void btnBlock2_Click(object sender, EventArgs e)
        {
            SelectPlayerAway.Block();
            DataGridView2Refresh();
            AwayPlayerShortInfo();
            listBox2.Items.Add($"<{label1.Text}> {SelectPlayerAway.PlayerName} Block");
        }

        private void btnFoul2_Click(object sender, EventArgs e)
        {
            SelectPlayerAway.Foul();
            DataGridView2Refresh();
            AwayPlayerShortInfo();
            listBox2.Items.Add($"<{label1.Text}> {SelectPlayerAway.PlayerName} Foul");
        }
        #endregion

        HomeTeamStats ts = new HomeTeamStats();
        AwayTeamStats ats = new AwayTeamStats();

        //////Sayaç Ayarları
        int _Second = 00;
        int _Minutes = 10;
        int time = -1, quarter = 1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            time++;
            if (time == 0)
            {
                listBox1.Items.Add("<10:00> " + label6.Text + "uarter Started");
                listBox2.Items.Add("<10:00> " + label6.Text + "uarter Started");
            }

            if (_Second == 0)
            {
                _Second = 60;
                _Minutes--;
            }
            _Second--;
            if (time >= 599)
            {
                if (quarter < 4)
                {
                    timer1.Stop();
                    TimerStartStop.Text = "Start";

                    listBox1.Items.Add("<00:00> " + label6.Text + "uarter Finished");
                    listBox2.Items.Add("<00:00> " + label6.Text + "uarter Finished");
                    quarter++;
                    label6.Text = $"{quarter}-Q";
                    _Second = 00;
                    _Minutes = 10;
                    time = -1;
                }
                else if (quarter == 4 && ts.HomeTotalScore != ats.AwayScore)
                {
                    timer1.Stop();
                    label6.Text = "Game Over";
                    listBox1.Items.Add("<00:00> Game Finished");
                    listBox2.Items.Add("<00:00> Game Finished");
                    MessageBox.Show("The game ended. Congratulations on both teams-(Maç bitti. İki takımıda tebrik ederiz)");

                    DataGridView1Refresh();
                    DataGridView2Refresh();
                    SelectFilePath();
                    SaveExcelHomeTeam();
                    SaveExcelAwayTeam();
                    SaveTxtHomeTeam();
                    SaveTxtAwayTeam();
                }
                else if (quarter == 4 && HomeScore == AwayScore)
                {
                    timer1.Stop();
                    TimerStartStop.Text = "Start";
                    label6.Text = "OT";
                    listBox1.Items.Add("<00:00> Game Finished");
                    _Second = 00;
                    _Minutes = 5;
                    time = 299;
                }

            }


            //Oyuncuların sahada kalma sürelerini tutuyoruz.
            for (int i = 0; i < HomePlayer.PlayerListHome.Count(); i++)
            {
                if (HomePlayer.PlayerListHome[i].SahadaMi == true)
                {
                    HomePlayer.PlayerListHome[i].zaman += TimeSpan.FromSeconds(1);
                }
            }
            for (int i = 0; i < AwayPlayer.PlayerListAway.Count(); i++)
            {
                if (AwayPlayer.PlayerListAway[i].SahadaMi == true)
                {
                    AwayPlayer.PlayerListAway[i].zaman += TimeSpan.FromSeconds(1);
                }
            }
            label1.Text = string.Format("{0:00}:{1:00}", _Minutes, _Second);
        }

        private void TimerStartStop_Click(object sender, EventArgs e)
        {
            panelHomeButtons.Enabled = true;
            panelAwayButtons.Enabled = true;
            if (flowLayoutPanel3.Controls.Count == 6 && flowLayoutPanel4.Controls.Count == 6)
            {
                if (TimerStartStop.Text == "Start")
                {
                    btnPlayerChanged.Enabled = true;
                    btn2PlayerChanged.Enabled = true;
                    timer1.Start();
                    btnPlayerChanged.BackColor = Color.Yellow;
                    btn2PlayerChanged.BackColor = Color.Yellow;
                    TimerStartStop.Text = "Stop";
                }
                else if (TimerStartStop.Text == "Stop")
                {
                    timer1.Stop();
                    TimerStartStop.Text = "Start";
                }
            }
            else
            {
                MessageBox.Show("Five players in two teams must be in the court - (İki takımında sahada 5 oyuncusu olmalı.)");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {//Ev sahibi takım seçimi
            LoadComboBox1();
            DataGridView1Refresh();
            flowLayoutPanel1.Controls.Clear();

            if (HomePlayer.PlayerListHome.Count() != 0)
            {
                for (int i = 0; i < HomePlayer.PlayerListHome.Count(); i++)
                {
                    Player.PlayerListHome[i].SahadaMi = false;
                    Button btn = new Button();
                    btn.Width = 75;
                    btn.Height = 45;
                    btn.BackColor = Color.White;
                    btn.Name = HomePlayer.PlayerListHome[i].PlayerName.Trim();
                    btn.Text = HomePlayer.PlayerListHome[i].No;
                    btn.Font = new Font("Tahoma", 18f, FontStyle.Bold);
                    flowLayoutPanel1.Controls.Add(btn);
                    btn.Click += buttonMetod3_Click;
                }
            }
            label4.Text = comboBox1.Text.ToUpper();
            comboBox1.Visible = false;
        }
        private void buttonMetod3_Click(object sender, EventArgs e)
        {//Ev Sahibi Takımın Oyuncu Buttonları
            if (btnPlayerChanged.BackColor == Color.Yellow)
            {
                foreach (Control item in flowLayoutPanel3.Controls)
                {
                    if (item is Button)
                    {
                        item.BackColor = Color.White;
                    }
                }
                Button btn = (Button)sender;

                if (btn.BackColor == Color.White)
                {
                    btn.BackColor = Color.Red;
                }
                SelectPlayerHome = HomePlayer.PlayerListHome.Where(x => x.No == btn.Text).First();
                HomePlayerShortInfo();
            }
            else if (btnPlayerChanged.BackColor == Color.Red)
            {
                Button btn = (Button)sender;
                if (flowLayoutPanel1.Controls.Contains(btn))
                {
                    if (flowLayoutPanel3.Controls.Count <= 5)
                    {
                        flowLayoutPanel3.Controls.Add(btn);
                        flowLayoutPanel1.Controls.Remove(btn);

                        SelectPlayerHome = HomePlayer.PlayerListHome.Where(x => x.No == btn.Text).First();
                        SelectPlayerHome.SahadaMi = true;
                    }
                }
                else if (flowLayoutPanel3.Controls.Contains(btn))
                {
                    flowLayoutPanel1.Controls.Add(btn);
                    flowLayoutPanel3.Controls.Remove(btn);
                    SelectPlayerHome = HomePlayer.PlayerListHome.Where(x => x.No == btn.Text).First();
                    SelectPlayerHome.SahadaMi = false;
                }
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {//Deplasman Takım Seçimi
            LoadComboBox2();
            DataGridView2Refresh();
            flowLayoutPanel2.Controls.Clear();
            if (AwayPlayer.PlayerListAway.Count() != 0)
            {
                for (int i = 0; i < AwayPlayer.PlayerListAway.Count(); i++)
                {
                    Player.PlayerListAway[i].SahadaMi = false;
                    Button btn2 = new Button();
                    btn2.Width = 75;
                    btn2.Height = 45;
                    btn2.BackColor = Color.White;
                    btn2.Name = AwayPlayer.PlayerListAway[i].PlayerName.Trim();
                    btn2.Text = AwayPlayer.PlayerListAway[i].No;
                    btn2.Font = new Font("Tahoma", 18f, FontStyle.Bold);
                    flowLayoutPanel2.Controls.Add(btn2);
                    btn2.Click += buttonMetod2_Click;
                }
            }
            label5.Text = comboBox2.Text.ToUpper();
            comboBox2.Visible = false;
        }

        private void buttonMetod2_Click(object sender, EventArgs e)
        {//Deplasman oyuncu butonları
            if (btn2PlayerChanged.BackColor == Color.Yellow)
            {
                foreach (Control item in flowLayoutPanel4.Controls)
                {
                    if (item is Button)
                    {
                        item.BackColor = Color.White;
                    }
                }
                Button btn2 = (Button)sender;
                if (btn2.BackColor == Color.White)
                {
                    btn2.BackColor = Color.Red;
                }
                SelectPlayerAway = AwayPlayer.PlayerListAway.Where(x => x.No == btn2.Text).First();
                AwayPlayerShortInfo();
            }
            else if (btn2PlayerChanged.BackColor == Color.Red)
            {
                Button btn2 = (Button)sender;
                if (flowLayoutPanel2.Controls.Contains(btn2))
                {
                    if (flowLayoutPanel4.Controls.Count <= 5)
                    {
                        flowLayoutPanel4.Controls.Add(btn2);
                        flowLayoutPanel2.Controls.Remove(btn2);
                        SelectPlayerAway = AwayPlayer.PlayerListAway.Where(x => x.No == btn2.Text).First();
                        SelectPlayerAway.SahadaMi = true;

                    }
                }
                else if (flowLayoutPanel4.Controls.Contains(btn2))
                {
                    flowLayoutPanel2.Controls.Add(btn2);
                    flowLayoutPanel4.Controls.Remove(btn2);
                    SelectPlayerAway = AwayPlayer.PlayerListAway.Where(x => x.No == btn2.Text).First();
                    SelectPlayerAway.SahadaMi = false;
                }
            }
        }
        private void btnPlayerChanged_Click(object sender, EventArgs e)
        {//Ev Sahibi OyuncuDeğişikliğiButonu
            if (btnPlayerChanged.BackColor == Color.Yellow)
            {
                flowLayoutPanel1.Enabled = true;
                flowLayoutPanel2.Enabled = true;
                TimerStartStop.Text = "Start";
                btnPlayerChanged.BackColor = Color.Red;
                btn2PlayerChanged.BackColor = Color.Red;
                timer1.Stop();
            }
            else if (btnPlayerChanged.BackColor == Color.Red)
            {
                flowLayoutPanel1.Enabled = false;
                flowLayoutPanel2.Enabled = false;
                btnPlayerChanged.BackColor = Color.Yellow;
                btn2PlayerChanged.BackColor = Color.Yellow;
                timer1.Start();
            }

        }

        private void btn2PlayerChanged_Click(object sender, EventArgs e)
        {//Deplasman Oyuncu Değişikliği Butonu
            if (btn2PlayerChanged.BackColor == Color.Yellow)
            {
                flowLayoutPanel1.Enabled = true;
                flowLayoutPanel2.Enabled = true;
                TimerStartStop.Text = "Start";
                btn2PlayerChanged.BackColor = Color.Red;
                btnPlayerChanged.BackColor = Color.Red;
                timer1.Stop();
            }
            else if (btn2PlayerChanged.BackColor == Color.Red)
            {
                flowLayoutPanel1.Enabled = false;
                flowLayoutPanel2.Enabled = false;
                btn2PlayerChanged.BackColor = Color.Yellow;
                btnPlayerChanged.BackColor = Color.Yellow;
                timer1.Start();
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (btnPlayerChanged.BackColor == Color.Yellow)
            {
                flowLayoutPanel1.Enabled = false;
            }
            else if (btnPlayerChanged.BackColor == Color.Red)
            {
                flowLayoutPanel1.Enabled = true;
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
            if (btn2PlayerChanged.BackColor == Color.Yellow)
            {
                flowLayoutPanel2.Enabled = false;
            }
            else if (btn2PlayerChanged.BackColor == Color.Red)
            {
                flowLayoutPanel2.Enabled = true;
            }
        }


        #region HomePlayer Reduce Buttons
        private void btnDefRebReduce_Click(object sender, EventArgs e)
        {
            if (SelectPlayerHome.DefensiveReboundCount > 0)
            {
                panelHomeReduce.Visible = false;
                SelectPlayerHome.DefRebReduce();
                DataGridView1Refresh();
                HomePlayerShortInfo();
            }
        }

        private void btn2ptReduce_Click(object sender, EventArgs e)
        {

            if (SelectPlayerHome.TwoPtMadeCount > 0 && SelectPlayerHome.TwoPtTryCount > 0)
            {
                panelHomeReduce.Visible = false;
                SelectPlayerHome.TwoPointReduce();
                SelectPlayerHome.TwoPointPer();
                DataGridView1Refresh();
                HomeScoreboardUpdate();
                HomePlayerShortInfo();
            }
            else if (SelectPlayerHome.TwoPtMadeCount == 0 && SelectPlayerHome.TwoPtTryCount > 0)
            {
                panelHomeReduce.Visible = false;
                SelectPlayerHome.TwoPointTryReduce();
                SelectPlayerHome.TwoPointPer();
                DataGridView1Refresh();
                HomeScoreboardUpdate();
                HomePlayerShortInfo();
            }

        }

        private void btn3ptReduce_Click(object sender, EventArgs e)
        {
            if (SelectPlayerHome.ThreePtMadeCount > 0 && SelectPlayerHome.ThreePtTryCount > 0)
            {
                panelHomeReduce.Visible = false;
                SelectPlayerHome.ThreePointReduce();
                SelectPlayerHome.ThreePointPer();
                DataGridView1Refresh();
                HomeScoreboardUpdate();
                HomePlayerShortInfo();
            }
            else if (SelectPlayerHome.ThreePtMadeCount == 0 && SelectPlayerHome.ThreePtTryCount > 0)
            {
                panelHomeReduce.Visible = false;
                SelectPlayerHome.ThreePointTRYReduce();
                SelectPlayerHome.ThreePointPer();
                DataGridView1Refresh();
                HomeScoreboardUpdate();
                HomePlayerShortInfo();
            }
        }

        private void btnFtReduce_Click(object sender, EventArgs e)
        {
            if (SelectPlayerHome.FreeThrowMadeCount > 0 && SelectPlayerHome.FreeThrowTryCount > 0)
            {
                panelHomeReduce.Visible = false;
                SelectPlayerHome.FTPointReduce();
                SelectPlayerHome.FTPointPer();
                DataGridView1Refresh();
                HomeScoreboardUpdate();
                HomePlayerShortInfo();
            }
            else if (SelectPlayerHome.FreeThrowMadeCount == 0 && SelectPlayerHome.FreeThrowTryCount > 0)
            {
                panelHomeReduce.Visible = false;
                SelectPlayerHome.FTPointTryReduce();
                SelectPlayerHome.FTPointPer();
                DataGridView1Refresh();
                HomeScoreboardUpdate();
                HomePlayerShortInfo();
            }
        }

        private void btnOffRebReduce_Click(object sender, EventArgs e)
        {
            if (SelectPlayerHome.OffensiveReboundCount > 0)
            {
                panelHomeReduce.Visible = false;
                SelectPlayerHome.OffRebReduce();
                DataGridView1Refresh();
                HomePlayerShortInfo();
            }
        }

        private void btnAsistReduce_Click(object sender, EventArgs e)
        {
            if (SelectPlayerHome.AsistCount > 0)
            {
                panelHomeReduce.Visible = false;
                SelectPlayerHome.AsistReduce();
                DataGridView1Refresh();
                HomePlayerShortInfo();
            }
        }

        private void btnTOReduce_Click(object sender, EventArgs e)
        {
            if (SelectPlayerHome.TO > 0)
            {
                panelHomeReduce.Visible = false;
                SelectPlayerHome.TOReduce();
                DataGridView1Refresh();
                HomePlayerShortInfo();
            }
        }

        private void btnStealReduce_Click(object sender, EventArgs e)
        {
            if (SelectPlayerHome.StealCount > 0)
            {
                panelHomeReduce.Visible = false;
                SelectPlayerHome.StealReduce();
                DataGridView1Refresh();
                HomePlayerShortInfo();
            }
        }

        private void btnBlockReduce_Click(object sender, EventArgs e)
        {
            if (SelectPlayerHome.BlockCount > 0)
            {
                panelHomeReduce.Visible = false;
                SelectPlayerHome.BlockReduce();
                DataGridView1Refresh();
                HomePlayerShortInfo();
            }
        }

        private void btnFoulReduce_Click(object sender, EventArgs e)
        {
            if (SelectPlayerHome.FoulCount > 0)
            {
                panelHomeReduce.Visible = false;
                SelectPlayerHome.FoulReduce();
                DataGridView1Refresh();
                HomePlayerShortInfo();
            }
        }
        #endregion


        #region AwayPlayer Reduce Buttons


        private void btn2ptReduce2_Click(object sender, EventArgs e)
        {
            if (SelectPlayerAway.TwoPtMadeCount > 0 && SelectPlayerAway.TwoPtTryCount > 0)
            {
                panelAwayReduce.Visible = false;
                SelectPlayerAway.TwoPointReduce();
                SelectPlayerAway.TwoPointPer();
                DataGridView2Refresh();
                AwayScoreboardUpdate();
                AwayPlayerShortInfo();
            }
            else if (SelectPlayerAway.TwoPtMadeCount == 0 && SelectPlayerAway.TwoPtTryCount > 0)
            {
                panelAwayReduce.Visible = false;
                SelectPlayerAway.TwoPointTryReduce();
                SelectPlayerAway.TwoPointPer();
                DataGridView2Refresh();
                AwayScoreboardUpdate();
                AwayPlayerShortInfo();
            }
        }

        private void btn3ptReduce2_Click(object sender, EventArgs e)
        {
            if (SelectPlayerAway.ThreePtMadeCount > 0 && SelectPlayerAway.ThreePtTryCount > 0)
            {
                panelAwayReduce.Visible = false;
                SelectPlayerAway.ThreePointReduce();
                SelectPlayerAway.ThreePointPer();
                DataGridView2Refresh();
                AwayScoreboardUpdate();
                AwayPlayerShortInfo();
            }
            else if (SelectPlayerAway.ThreePtMadeCount == 0 && SelectPlayerAway.ThreePtTryCount > 0)
            {
                panelAwayReduce.Visible = false;
                SelectPlayerAway.ThreePointTRYReduce();
                SelectPlayerAway.ThreePointPer();
                DataGridView2Refresh();
                AwayScoreboardUpdate();
                AwayPlayerShortInfo();
            }
        }

        private void btnFtReduce2_Click(object sender, EventArgs e)
        {
            if (SelectPlayerAway.FreeThrowMadeCount > 0 && SelectPlayerAway.FreeThrowTryCount > 0)
            {
                panelAwayReduce.Visible = false;
                SelectPlayerAway.FTPointReduce();
                SelectPlayerAway.FTPointPer();
                DataGridView2Refresh();
                AwayScoreboardUpdate();
                AwayPlayerShortInfo();
            }
            else if (SelectPlayerAway.FreeThrowMadeCount == 0 && SelectPlayerAway.FreeThrowTryCount > 0)
            {
                panelAwayReduce.Visible = false;
                SelectPlayerAway.FTPointTryReduce();
                SelectPlayerAway.FTPointPer();
                DataGridView2Refresh();
                AwayScoreboardUpdate();
                AwayPlayerShortInfo();
            }
        }

        private void btnDefRebReduce2_Click(object sender, EventArgs e)
        {
            if (SelectPlayerAway.DefensiveReboundCount > 0)
            {
                panelAwayReduce.Visible = false;
                SelectPlayerAway.DefRebReduce();
                DataGridView2Refresh();
                AwayPlayerShortInfo();
            }
        }

        private void btnOffRebReduce2_Click(object sender, EventArgs e)
        {
            if (SelectPlayerAway.OffensiveReboundCount > 0)
            {
                panelAwayReduce.Visible = false;
                SelectPlayerAway.OffRebReduce();
                DataGridView2Refresh();
                AwayPlayerShortInfo();
            }
        }

        private void btnAsistReduce2_Click(object sender, EventArgs e)
        {
            if (SelectPlayerAway.AsistCount > 0)
            {
                panelAwayReduce.Visible = false;
                SelectPlayerAway.AsistReduce();
                DataGridView2Refresh();
                AwayPlayerShortInfo();
            }
        }

        private void btnTOReduce2_Click(object sender, EventArgs e)
        {
            if (SelectPlayerAway.TO > 0)
            {
                panelAwayReduce.Visible = false;
                SelectPlayerAway.TOReduce();
                DataGridView2Refresh();
                AwayPlayerShortInfo();
            }
        }

        private void btnStealReduce2_Click(object sender, EventArgs e)
        {
            if (SelectPlayerAway.StealCount > 0)
            {
                panelAwayReduce.Visible = false;
                SelectPlayerAway.StealReduce();
                DataGridView2Refresh();
                AwayPlayerShortInfo();
            }
        }

        private void btnBlockReduce2_Click(object sender, EventArgs e)
        {
            if (SelectPlayerAway.BlockCount > 0)
            {
                panelAwayReduce.Visible = false;
                SelectPlayerAway.BlockReduce();
                DataGridView2Refresh();
                AwayPlayerShortInfo();
            }
        }

        private void btnFoulReduce2_Click(object sender, EventArgs e)
        {
            if (SelectPlayerAway.FoulCount > 0)
            {
                panelAwayReduce.Visible = false;
                SelectPlayerAway.FoulReduce();
                DataGridView2Refresh();
                AwayPlayerShortInfo();
            }
        }
        #endregion

        string FilePath;
        private void SelectFilePath()
        {
            FilePath = "";
            var fbd = new FolderBrowserDialog();
            DialogResult d = fbd.ShowDialog();
            if (d == DialogResult.OK)
            {
                FilePath = fbd.SelectedPath;

            }

        }

        private void SaveExcelHomeTeam()
        {
            var tbl = new DataTable();
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if (column.Visible)
                {
                    tbl.Columns.Add(column.HeaderText);
                }
            }

            object[] cellValues = new object[dataGridView1.Columns.Count];
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                tbl.Rows.Add(cellValues);
            }

            try
            {
                if (tbl == null || tbl.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Boş veya geçersiz tablo!\n");

                // load excel, and create a new workbook
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Workbooks.Add();

                // single worksheet
                Microsoft.Office.Interop.Excel._Worksheet workSheet = excelApp.ActiveSheet;

                // column headings
                for (var i = 0; i < tbl.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
                }

                // rows
                for (var i = 0; i < tbl.Rows.Count; i++)
                {
                    // to do: format datetime values before printing
                    for (var j = 0; j < tbl.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
                    }
                }

                // check file path
                if (!string.IsNullOrEmpty(FilePath))
                {
                    try
                    {
                        string filename = (DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-HomeTeam-" + label4.Text + "-" + label5.Text + ".xlsx").ToLower();
                        var engname = String.Join("", filename.Normalize(NormalizationForm.FormD)
                        .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
                        workSheet.SaveAs(FilePath + "\\" + engname);
                        excelApp.Quit();
                        MessageBox.Show("Excel dosyası kaydedildi!");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Kayıt başarısız. Kaydetme yolunu kontrol edin.\n"
                                            + ex.Message);
                    }
                }
                else
                { // no file path is given
                    excelApp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
        private void SaveExcelAwayTeam()
        {
            var tbl = new DataTable();
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                if (column.Visible)
                {
                    tbl.Columns.Add(column.HeaderText);
                }
            }

            object[] cellValues = new object[dataGridView2.Columns.Count];
            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    cellValues[i] = row.Cells[i].Value;
                }
                tbl.Rows.Add(cellValues);
            }

            try
            {
                if (tbl == null || tbl.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Boş veya geçersiz tablo!\n");

                // load excel, and create a new workbook
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Workbooks.Add();

                // single worksheet
                Microsoft.Office.Interop.Excel._Worksheet workSheet = excelApp.ActiveSheet;

                // column headings
                for (var i = 0; i < tbl.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = tbl.Columns[i].ColumnName;
                }

                // rows
                for (var i = 0; i < tbl.Rows.Count; i++)
                {
                    // to do: format datetime values before printing
                    for (var j = 0; j < tbl.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = tbl.Rows[i][j];
                    }
                }

                // check file path
                if (!string.IsNullOrEmpty(FilePath))
                {
                    try
                    {
                        string filename = (DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-AwayTeam-" + label4.Text + "-" + label5.Text + ".xlsx").ToLower();
                        var engname = String.Join("", filename.Normalize(NormalizationForm.FormD)
                        .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
                        workSheet.SaveAs(FilePath + "\\" + engname);
                        excelApp.Quit();
                        MessageBox.Show("Files are stored in the selected folder - (Dosyalar seçili klasöre kayıt edildi!)");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Kayıt başarısız. Kaydetme yolunu kontrol edin.\n"
                                            + ex.Message);
                    }
                }
                else
                { // no file path is given
                    excelApp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }


        private void SaveTxtHomeTeam()
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                try
                {
                    string filename = (DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-HomeTeam-" + label4.Text + "-" + label5.Text + ".txt").ToLower();
                    var engname = String.Join("", filename.Normalize(NormalizationForm.FormD)
                    .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
                    System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(FilePath + "\\" + engname);
                    foreach (var item in listBox1.Items)
                    {
                        SaveFile.WriteLine(item.ToString());
                    }
                    SaveFile.ToString();
                    SaveFile.Close();
                }
                catch { }
            }
        }

        private void SaveTxtAwayTeam()
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                try
                {
                    string filename = (DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + "-AwayTeam-" + label4.Text + "-" + label5.Text + ".txt").ToLower();
                    var engname = String.Join("", filename.Normalize(NormalizationForm.FormD)
                    .Where(c => char.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark));
                    System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(FilePath + "\\" + engname);
                    foreach (var item in listBox2.Items)
                    {
                        SaveFile.WriteLine(item.ToString());
                    }
                    SaveFile.ToString();
                    SaveFile.Close();
                }
                catch { }
            }
        }


        private void btnExcel_Click(object sender, EventArgs e)
        {
            DataGridView1Refresh();
            DataGridView2Refresh();
            SelectFilePath();
            SaveExcelHomeTeam();
            SaveExcelAwayTeam();
            SaveTxtHomeTeam();
            SaveTxtAwayTeam();
        }

        private void btnHomeMistake_Click(object sender, EventArgs e)
        {
            TabControlSelectHome();
            btnDeleteH.Enabled = true;
            panelHomeReduce.Visible = true;
        }

        private void btnAwayMistake_Click(object sender, EventArgs e)
        {
            TabControlSelectAway();
            btnDeleteA.Enabled = true;
            panelAwayReduce.Visible = true;
        }

        private void btnDeleteH_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void btnDeleteA_Click(object sender, EventArgs e)
        {
            listBox2.Items.Remove(listBox2.SelectedItem);
        }

        private void restartGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            new StatisticView().Show();
        }

        private void btnTeamStatShow_Click(object sender, EventArgs e)
        {
            TeamStats ts = new TeamStats();
            ts.label1.Text = label4.Text;
            ts.label3.Text = label5.Text;
            ts.Show();

        }

        private void teamStatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TeamStats ts = new TeamStats();
            ts.label1.Text = label4.Text;
            ts.label3.Text = label5.Text;
            ts.Show();


        }
    }
}
