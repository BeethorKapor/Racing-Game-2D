using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Racing_Game_MOO_ICT
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.playground);
            playCrash.Stop();
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer playCrash = new System.Media.SoundPlayer(Properties.Resources.playground);
            playCrash.Stop();
            this.Close();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSetting frmS = new FormSetting();
            frmS.Show();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHelp frmHelp = new FormHelp();
            frmHelp.Show();
        }
    }
}
