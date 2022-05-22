using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media; /* otetaan käyttöön system.windows.media äänenhallintaa varten.
                             Tätä varten lisäätän reference PresentationCore.dll sekä windows base*/

namespace EscapeRoom
{
    public partial class Pelialue : Form
    {
       
        public Pelialue()
        {
            InitializeComponent();
            HuoneEkaPL.Visible = true;
            HuoneTokaPL.Visible = false;
            HuoneKolmasPL.Visible = false;

            AvainPB.Visible = false;
            JaakaappiOviAukiPB.Visible = false;
            PakastinOviAukiPB.Visible = false;


        }

        Katsottavat katsottavat = new Katsottavat();
        List<PictureBox> collected = new List<PictureBox>();
        int x, y;
        Image ItemName;
        bool reppu = false;

        private void NuoliOikeaPB_Click(object sender, EventArgs e) // nuoli ruokailutilaan
        {
            HuoneTokaPL.Visible = true;
            HuoneEkaPL.Visible = false;
        }

        private void NuoliVasenPB_Click(object sender, EventArgs e) // nuoli takaisin keittiöön
        {
            HuoneTokaPL.Visible = false;
            HuoneEkaPL.Visible = true;
            
        }

        private void NuoliVasemmallePB_Click(object sender, EventArgs e) // nuoli makuuhuoneeseen
        {
            HuoneKolmasPL.Visible = true;
            HuoneEkaPL.Visible = false;
        }

        private void NuoliOikeallePB_Click(object sender, EventArgs e) // nuoli takaisin keittiöön
        {
            HuoneKolmasPL.Visible = false;
            HuoneEkaPL.Visible = true;
        }



        //interaktiiviset asiat
        private void JaakaappiOviKiinniPB_Click(object sender, EventArgs e)
        {
            JaakaappiOviKiinniPB.Visible = false;
            JaakaappiOviAukiPB.Visible = true;

        }

        private void JaakaappiOviAukiPB_Click(object sender, EventArgs e)
        {
            JaakaappiOviKiinniPB.Visible = true;
            JaakaappiOviAukiPB.Visible = false;
           
        }


        private void PakastinOviKiinni_Click(object sender, EventArgs e)
        {
            PakastinOviKiinni.Visible = false;
            PakastinOviAukiPB.Visible = true;
        }

        private void PakastinOviAukiPB_Click(object sender, EventArgs e)
        {
            PakastinOviKiinni.Visible = true;
            PakastinOviAukiPB.Visible = false;
        }


        //katsottavat asiat 
        private void KatsoTavaraa_Click(object sender, EventArgs e)
        {
            PictureBox PicBox = sender as PictureBox;
            katsottavat.LookAt(PicBox.Name);
        }
        // Katsottavat asiat end
        

        private void ReppuPB_Click(object sender, EventArgs e)
        {
            reppu = true;
            ReppuPB.Visible = false;
            InventaarioPB.Visible = true;
        }

       

        private void LappuPB_Click(object sender, EventArgs e)
        {
            LappuIsoPB.Visible = true;
        }

        private void LappuIsoPB_Click(object sender, EventArgs e)
        {
            LappuIsoPB.Visible = false;
        }

        private void PCPB_Click(object sender, EventArgs e)
        {
            String Viesti = "Avaa tietokone?";
            switch (MessageBox.Show(Viesti, "Tietokone", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    RuutuPB.Visible = true;
                    PCPB.Enabled = false;
                    break;
                case DialogResult.No:
                    RuutuPB.Visible = false;
                    break;
            }
        }

        private void RuutuPB_Click(object sender, EventArgs e)
        {
            RuutuPB.Visible = false;
            FullscreenPL.Visible = true;
            SuljeMuistioBT.Visible = false;

        }

        private void SuljeFullscreenLB_Click(object sender, EventArgs e)
        {
            RuutuPB.Visible = true;
            FullscreenPL.Visible = false;
            CreditsTB.Visible = false;
            SuljeMuistioBT.Visible = false;
        }

        private void MuistioPB_Click(object sender, EventArgs e)
        {
            CreditsTB.Visible = true;
            SuljeMuistioBT.Visible = true;

        }

        private void SuljeMuistioBT_Click(object sender, EventArgs e)
        {
            CreditsTB.Visible = false;
            SuljeMuistioBT.Visible = false;
        }



        //interaktiiviset asiat end

        //inventory
        private void tavarat_Click(object sender, EventArgs e)
        {
            if (reppu == false) MessageBox.Show("Et voi vielä kerätä tavaroita");
            
            else
            {
                PictureBox tavara = sender as PictureBox;
                //MessageBox.Show(tavara.Name.ToString());
                AddInvetory(tavara.Image, tavara.Name);
                tavara.Visible = false;
            }
            


        }

        private void Invetory_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(sender.ToString());
            PictureBox esine = sender as PictureBox;
            esine.BorderStyle = BorderStyle.FixedSingle;


            if (ItemName == esine.Image)
            {
                MessageBox.Show("samat");
                ItemName = null;
            }
            else if (ItemName != null)
            {
                MessageBox.Show("eri");
                //UseInventory(ItemName, testi.Image);
            }
            else
            {
                MessageBox.Show("tyhjä");
                ItemName = esine.Image;
            }

        }
        private void AddInvetory(Image thing, string thingName)
        {
            //MessageBox.Show(thing.ToString());
            PictureBox item = new PictureBox();
            item.Image = thing;
            item.Tag = thingName;
            item.Width = 50;
            item.Height = 50;
            item.SizeMode = PictureBoxSizeMode.Zoom;
            item.Click += new EventHandler(Invetory_Click);

            x = collected.Count * 60;
            y = 5;
            item.Location = new Point(x, y);

            collected.Add(item);
            InventaarioPB.Controls.Add(item);

        }
        /*
        private void UseInventory(Image item1, Image item2)
        {
            if (item1.Tag == tavara1 && item2.Tag == tavara2)
            {
                MessageBox.Show("Käytit tavara 1 ja 2");
            }

        }
        */
        //inventory end


    }
}
