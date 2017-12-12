using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Web.Script.Serialization;

namespace BasketbolIstatik
{
    public partial class AddTeam : Form
    {
        public AddTeam()
        {
            InitializeComponent();
        }
        
        public void Save()
        {
            //System.Web.Extensions referansını ekledik.
            JavaScriptSerializer tercuman = new JavaScriptSerializer();
            string ceviri = tercuman.Serialize(Player.PlayerList);
            string dosyaAdi = $"{tbTeamName.Text.Trim()}.json";
            File.WriteAllText(dosyaAdi, ceviri);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                Player p = new Player();
                p.TeamName = tbTeamName.Text;
                p.PlayerName = textBox1.Text;
                p.No = textBox2.Text;
                Player.PlayerList.Add(p);
            }
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                Player p2 = new Player();
                p2.TeamName = tbTeamName.Text;
                p2.PlayerName = textBox3.Text;
                p2.No = textBox4.Text;
                Player.PlayerList.Add(p2);
            }
            if (textBox5.Text != "" && textBox6.Text != "")
            {
                Player p3 = new Player();
                p3.TeamName = tbTeamName.Text;
                p3.PlayerName = textBox5.Text;
                p3.No = textBox6.Text;
                Player.PlayerList.Add(p3);
            }
            if (textBox7.Text != "" && textBox8.Text != "")
            {
                Player p4 = new Player();
                p4.TeamName = tbTeamName.Text;
                p4.PlayerName = textBox7.Text;
                p4.No = textBox8.Text;
                Player.PlayerList.Add(p4);
            }
            if (textBox9.Text != "" && textBox10.Text != "")
            {
                Player p5 = new Player();
                p5.TeamName = tbTeamName.Text;
                p5.PlayerName = textBox9.Text;
                p5.No = textBox10.Text;
                Player.PlayerList.Add(p5);
            }
            if (textBox11.Text != "" && textBox12.Text != "")
            {
                Player p6 = new Player();
                p6.TeamName = tbTeamName.Text;
                p6.PlayerName = textBox11.Text;
                p6.No = textBox12.Text;
                Player.PlayerList.Add(p6);
            }
            if (textBox13.Text != "" && textBox14.Text != "")
            {
                Player p7 = new Player();
                p7.TeamName = tbTeamName.Text;
                p7.PlayerName = textBox13.Text;
                p7.No = textBox14.Text;
                Player.PlayerList.Add(p7);
            }
            if (textBox15.Text != "" && textBox16.Text != "")
            {
                Player p8 = new Player();
                p8.TeamName = tbTeamName.Text;
                p8.PlayerName = textBox15.Text;
                p8.No = textBox16.Text;
                Player.PlayerList.Add(p8);
            }
            if (textBox17.Text != "" && textBox18.Text != "")
            {
                Player p9 = new Player();
                p9.TeamName = tbTeamName.Text;
                p9.PlayerName = textBox17.Text;
                p9.No = textBox18.Text;
                Player.PlayerList.Add(p9);
            }
            if (textBox19.Text != "" && textBox20.Text != "")
            {
                Player p10 = new Player();
                p10.TeamName = tbTeamName.Text;
                p10.PlayerName = textBox19.Text;
                p10.No = textBox20.Text;
                Player.PlayerList.Add(p10);
            }
            if (textBox21.Text != "" && textBox22.Text != "")
            {
                Player p11 = new Player();
                p11.TeamName = tbTeamName.Text;
                p11.PlayerName = textBox21.Text;
                p11.No = textBox22.Text;
                Player.PlayerList.Add(p11);
            }
            if (textBox23.Text != "" && textBox24.Text != "")
            {
                Player p12 = new Player();
                p12.TeamName = tbTeamName.Text;
                p12.PlayerName = textBox23.Text;
                p12.No = textBox24.Text;
                Player.PlayerList.Add(p12);
            }
            Save();
            this.Dispose();
            new AddTeam().Show();
            MessageBox.Show("Basketball team was recorded. - (Takım kayıt edildi.)");
        }
        DirectoryInfo fileInfo;
        private void AddTeam_Load(object sender, EventArgs e)
        {
            fileInfo = new DirectoryInfo(Environment.CurrentDirectory);

            foreach (FileInfo item in fileInfo.GetFiles("*.json"))
            {
                listBox1.Items.Add(item.Name.Replace(".json", ""));
            }
        }
       
        private void button2_Click(object sender, EventArgs e)
        {
            string FileName = Environment.CurrentDirectory+"//"+listBox1.SelectedItem+".json";
            File.Delete(FileName);
            MessageBox.Show("Team Deleted - (Seçili takım silindi.)");
            this.Dispose();
            new AddTeam().Show();
        }
    }
    
}
