using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyPoint
{
    public partial class gallery_big : Form
    {
        public gallery_big()
        {
            InitializeComponent();
            
            
        }
        int number;
        public static int Number { get; set; }
        
        public void ShowBigPic(int luku)
        {
            number = luku;
            BigGalPicPB.Image = BigPicList.Images[number]; 
            if (number == 0)
            {
                
            }
            else if(number == 1)
            {
                BigGalPicPB.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
            }
            else if (number == 3)
            {
                BigGalPicPB.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (number == 7)
            {
                BigGalPicPB.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            }
            else if (number == 12)
            {
                MessageBox.Show("You found hidden treasure");
            }
                        
        }
        private void bigImageNextBT_Click(object sender, EventArgs e)
        {
            if (number == BigPicList.Images.Count -1)
            {
                bigImageNextBT.Enabled = false;
            }
            else
            {
                number++;
                ShowBigPic(number);
                bigImageBackBT.Enabled = true;
            }
            
            
        }

        private void bigImageBackBT_Click(object sender, EventArgs e)
        {
            if (number == 0)
            {
                bigImageBackBT.Enabled = false;
            }
            else
            {
                number--;
                ShowBigPic(number);
                bigImageNextBT.Enabled = true;
            }
            

        }
    }
}
