﻿using System;
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

            AvainPB.Visible = false;
            JaakaappiOviAukiPB.Visible = false;
            PakastinOviAukiPB.Visible = false;
            MaitoPB.Visible = false;
            KetsuppiPB.Visible = false;

        }
        List<PictureBox> collected = new List<PictureBox>();
        int x, y;
        Image ItemName;
        bool reppu = false;


        //interaktiiviset asiat
        private void JaakaappiOviKiinniPB_Click(object sender, EventArgs e)
        {
            JaakaappiOviKiinniPB.Visible = false;
            JaakaappiOviAukiPB.Visible = true;
            MaitoPB.Visible=true;
            KetsuppiPB.Visible =true;
        }

        private void ReppuPB_Click(object sender, EventArgs e)
        {
            reppu = true;
            ReppuPB.Visible = false;
        }

        private void AmpariPB_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This... is a bucket");
            MessageBox.Show("D E A R   G O D . . .");
            MessageBox.Show("There's more!");
            MessageBox.Show("N O !");
            MessageBox.Show("It contains a number... 9");



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

        private void Tavarat(object sender, EventArgs e)
        {
           
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
