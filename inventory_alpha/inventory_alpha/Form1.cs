using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory_alpha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<PictureBox> collected = new List<PictureBox>();
        int x, y;
        Image ItemName;

              

        private void tavarat_Click(object sender, EventArgs e)
        {
            
            PictureBox testi = sender as PictureBox;
            MessageBox.Show(testi.Name.ToString());
            AddInvetory(testi.Image, testi.Name);
            testi.Visible = false;


        }
        
        private void Invetory_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sender.ToString());
            PictureBox testi = sender as PictureBox;
            testi.BorderStyle = BorderStyle.FixedSingle;
            

            if (ItemName == testi.Image)
            {
                MessageBox.Show("samat");
                ItemName = null;
            }
            else if (ItemName != null)
            {
                MessageBox.Show("eri");
                UseInventory(ItemName, testi.Image);
            }
            else
            {
                MessageBox.Show("tyhjä");
                ItemName = testi.Image;
            }
            
        }

        private void AddInvetory(Image thing, string thingName)
        {
            MessageBox.Show(thing.ToString() );
            PictureBox item = new PictureBox();
            item.Image = thing;
            item.Tag = thingName;
            item.Width = 55;
            item.Height = 55;
            item.SizeMode = PictureBoxSizeMode.Zoom;
            item.Click += new EventHandler(Invetory_Click);

            x = collected.Count * 60;
            y = 0;
            item.Location = new Point(x, y);

            collected.Add(item);
            invetory.Controls.Add(item);

        }

        private void UseInventory(Image item1, Image item2)
        {
            if (item1.Tag == tavara1 && item2.Tag == tavara2)
            {
                MessageBox.Show("Käytit tavara 1 ja 2");
            }

        }
    }
}
