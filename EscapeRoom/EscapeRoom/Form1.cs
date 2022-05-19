using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscapeRoom
{
    public partial class Pelialue : Form
    {
        public Pelialue()
        {
            InitializeComponent();

            AvainPB.Visible = false;
            JaakaappiOviAukiPB.Visible = false;
            PakastinOviAukiPB.Visible = false;
            MaitoPB.Visible = false;
            KetsuppiPB.Visible = false;

            
        }

        private void AmpariPB_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a bucket");
            MessageBox.Show("DEAR GOD...");
            MessageBox.Show("There's more!");
            MessageBox.Show("NO!!");
            MessageBox.Show("It contains a number... 9");
        }
    }
}
