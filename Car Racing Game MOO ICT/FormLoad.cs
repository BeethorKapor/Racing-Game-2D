using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Car_Racing_Game_MOO_ICT
{
    public partial class FormLoad : Form
    {
        public FormLoad()
        {
            InitializeComponent();
        }

        private void FormLoad_Load(object sender, EventArgs e)
        {
            timerLoad.Start();
        }

        private void timerLoad_Tick(object sender, EventArgs e)
        {
            progressBarLoad.Value += 1;
            txtLoad.Text = progressBarLoad.Value.ToString() + "%";

            if (progressBarLoad.Value == 100)
            {
                progressBarLoad.Value = 0;
                timerLoad.Stop();
                this.Hide();
                FormMain frmM = new FormMain();
                frmM.Show();
            }
        }
    }
}
