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
    public partial class BasketballStatistic : Form
    {
        public BasketballStatistic()
        {
            InitializeComponent();
        }

        //Start Game Button
        private void button2_Click(object sender, EventArgs e)
        {
            new StatisticView().Show();
        }

        //Add Team Button
        private void button1_Click(object sender, EventArgs e)
        {
            new AddTeam().Show();
        }

        //Exit Button
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
