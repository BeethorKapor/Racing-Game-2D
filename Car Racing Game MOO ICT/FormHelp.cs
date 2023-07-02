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
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();
        }

        private void btnCloseHelp_Click(object sender, EventArgs e)
        {
            this.Close();
            FormMain frmM = new FormMain();
            frmM.Show();
        }
    }
}
