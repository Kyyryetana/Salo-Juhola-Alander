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

            Sound();
            HuoneEkaPL.Visible = true;
            HuoneTokaPL.Visible = false;
            HuoneKolmasPL.Visible = false;

            AvainPB.Visible = false;
            JaakaappiOviAukiPB.Visible = false;
            PakastinOviAukiPB.Visible = false;
            MakeDict();


        }
        Kaytettavat kaytettavat = new Kaytettavat();
        Kerattavat kerattavat = new Kerattavat();
        Katsottavat katsottavat = new Katsottavat();
        List<PictureBox> collected = new List<PictureBox>();
        int x, y;
        Image ItemName;
        bool reppu = false;
        Dictionary<string, PictureBox> collectedDict = new Dictionary<string, PictureBox>();
        Dictionary<string, PictureBox> collectiveBoxes = new Dictionary<string, PictureBox>();
        PictureBox ItemBox = null;

        // tekee kirjaston asioista jonka avulla voi lisätä tai poistaa asioita... tähän olisi hyvä lisätä kaikki olevat elementit jos niihin tahtoo toiminnallisuuden.
        private void MakeDict()
        {
            
            collectiveBoxes.Add("ReppuPB", ReppuPB);
            collectiveBoxes.Add("TakkiPB", TakkiPB);
            collectiveBoxes.Add("KengatPB", KengatPB);
            collectiveBoxes.Add("HuiviPB", HuiviPB);
            collectiveBoxes.Add("TaskulamppuPB", TaskulamppuPB);
            collectiveBoxes.Add("MankkaPB", MankkaPB);
            collectiveBoxes.Add("SprayPB", SprayPB);
            collectiveBoxes.Add("SipsiPB", SipsiPB);
            collectiveBoxes.Add("EsPB", EsPB);
            collectiveBoxes.Add("AvainPB", AvainPB);
            collectiveBoxes.Add("OviKiinniPB", OviKiinniPB);
            collectiveBoxes.Add("OviAukiPB", OviAukiPB);
            collectiveBoxes.Add("LappuPB", LappuPB);

            
        }

        
        

       
        private void Sound()
        {
            SoundPlayer soundPlayer = new SoundPlayer(@"Resources\the-street-market-danger-lion-x-main-version-11368-03-01.wav");
            soundPlayer.Play();
            soundPlayer.PlayLooping();
        }


        private void SoundOffBT_Click(object sender, EventArgs e)
        {
            SoundPlayer soundPlayer = new SoundPlayer();
            soundPlayer.Stop();
            SoundOffBT.Visible = false;
            SoundOnBT.Visible = true;
        }

        private void SoundOnBT_Click(object sender, EventArgs e)
        {
            Sound();
            SoundOffBT.Visible = true;
            SoundOnBT.Visible = false;
        }



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
            PictureBox PicBox = sender as PictureBox; //ottaa lähettävän pictureboxin muuttujaan
            if (ItemName != null)
            {
                Invetory_Click(sender, e);
            }
            else
            {
                katsottavat.LookAt(PicBox.Name); //kutsuu luokasta katsottavat metodia joka tekee pictureboxin nimen mukaan päättää mitä tehdään.
            }
            
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

        // tietokoneen ruutu 
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
            RickPB.Visible = false;
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

        private void VideoPB_Click(object sender, EventArgs e)
        {
            RickPB.Visible = true;
        }
        // tietokoneen ruutu end


        //avainlaatikon toiminta
        private void LaatikkoKiinniPB_Click(object sender, EventArgs e)
        {
            laatikkoPL.Visible = true;
            vihjeLB.BackColor = System.Drawing.Color.Transparent;
        }

        private void suljeLaatikkoBT_Click(object sender, EventArgs e)
        {
            laatikkoPL.Visible = false;
        }

        private void onkoOikeaKoodiBT_Click(object sender, EventArgs e)
        {
            
            if (ekaNumeroNUD.Value == 0 && tokaNumeroNUD.Value == 9 && kolmasNumeroNUD.Value == 2)
            {
                MessageBox.Show("MENE TÖIHIN!");
                MessageBox.Show("eiku...");
                MessageBox.Show("Hienoa! Sait laatikosta avaimen.");

                laatikkoPL.Visible = false;
                AvainPB.Visible = true;
                LaatikkoKiinniPB.Visible = false;
                LaatikkoAukiPB.Visible = true;
            }

            else
            {
                MessageBox.Show("Kokeile lukuja eri järjestyksessä.");
            }
        }

        private void vihjeLB_Click(object sender, EventArgs e)
        {
            string apua = "Mestarit eivät tarvitse vihjeitä, toisaalta eiväthän kaikki voi olla sekä fiksuja että filmaattisia samaan aikaan.\n" +
                "\nTahdotko varmasti helpotusta peliin?";
            switch (MessageBox.Show(apua, "Apua", MessageBoxButtons.YesNo))
            {
                case DialogResult.Yes:
                    MessageBox.Show("Saatan olla hieman pettynyt sinuun. \nKäytä kaunista maisemataulua apunasi.");
                    break;
                case DialogResult.No:
                    MessageBox.Show("Hienoa! Luotan sinuun!");
                    break;
            }

        }

        private void LaatikkoAukiPB_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sait jo avaimen täältä, ei täällä ketää enää oo. Tää on ihan noupadi.");
        }

        //avainlaatikon toiminta loppu


        //interaktiiviset asiat end

        //inventory
        private void tavarat_Click(object sender, EventArgs e)
        {
            PictureBox tavara = sender as PictureBox;
            kerattavat.PickUp(tavara.Name.ToString());
            if (tavara == TakkiPB || tavara == KengatPB|| tavara == HuiviPB)
            {
                tavara.Visible = false;
                //collected.Add(tavara);
            }
            else if (reppu == false) MessageBox.Show("Sinulla ei ole mitään mihin laittaa tavaroita.");
            
            else
            {
                
                //MessageBox.Show(tavara.Name.ToString());
                AddInvetory(tavara.Image, tavara.Name);
                tavara.Visible = false;
            }
            


        }
        //inventaarion klikkaus
        private void Invetory_Click(object sender, EventArgs e)
        {
            
            //MessageBox.Show(sender.ToString());
            PictureBox esine = sender as PictureBox;
            esine.BorderStyle = BorderStyle.FixedSingle;


            if (ItemName == esine.Image)
            {
                MessageBox.Show("samat");
                ItemName = null;
                esine.BorderStyle= BorderStyle.None;
                
            }
            else if (ItemName != null)
            {
                MessageBox.Show("eri");
                //UseInventory(ItemName, testi.Image);
                esine.BorderStyle = BorderStyle.None;
                ItemBox.BorderStyle = BorderStyle.None;
                
                
                List<string> list = kaytettavat.UseItem(ItemName.Tag.ToString(), esine.Name.ToString());
                
                
                if (list != null)
                {
                    bool poista = false;
                    foreach (string s in list)
                    {
                        if (poista == true)
                        {
                            PictureBox kokeilua = collectiveBoxes[s];
                            kokeilua.Visible = false;
                        }
                        else if (s == "_")
                        {
                            poista = true;
                        }
                        else
                        {

                            PictureBox kokeilua = collectiveBoxes[s];
                            kokeilua.Visible = true;
                        }   
                        

                    }
                    object[] testi = MuutaObject(list);
                    testi[0] = true;
                    ItemBox.BorderStyle = BorderStyle.None;
                    
                }
                ItemName = null;
            }
            else
            {
                MessageBox.Show("tyhjä");
                ItemName = esine.Image;
                ItemName.Tag = esine.Name.ToString();
                ItemBox = esine;

            }

        }

      
        // lisää invetaarioon uuden pictureboxin
        private void AddInvetory(Image thing, string thingName)
        {
            //MessageBox.Show(thing.ToString());
            PictureBox item = new PictureBox();
            item.Image = thing;
            item.Tag = thingName;
            item.Name = thingName+"inv";
            item.Width = 50;
            item.Height = 50;
            item.SizeMode = PictureBoxSizeMode.Zoom;
            item.Click += new EventHandler(Invetory_Click);
            collectiveBoxes.Add(thingName.ToString()+"inv", item);

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

        private object[] MuutaObject(List<string> lista)
        {
            object[] muutettavat = lista.ToArray<object>();
            return muutettavat;
        }

    }
}
