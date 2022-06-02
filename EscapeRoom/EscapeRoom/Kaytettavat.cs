using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EscapeRoom
{
    internal  class Kaytettavat
    {
        List<string> lisaa = new List<string>();
        
        public List<string> Lisaa { get; set; }


        /// <summary>
        /// Lisää dico sanan jälkeen pictureboxin nimi yhdistelmänä minkä jälkeen Func + numero perään ja
        /// mene sen jälkeen luomaan metodi mihin voit lisätä esineet mitä pitää saada näkyviin.
        /// Poistaaksesi elementtejä lisää ensin 
        /// lisaa.Add("_");
        /// Jonka jälkeen voit lisätä poistettavat elementit.
        /// </summary>
        /// <param name="esine1">käytettävä esine</param>
        /// <param name="esine2">Esine mihin halutaan käyttää ensin valittu tavara</param>
        /// <returns>palauttaa listan lisättävistä ja poistettavista elementeistä</returns>
        public List<string> UseItem(string esine1, string esine2)
        {
            string yhdistetty = esine1 + esine2;
            try
            {
                // store
                var dico = new Dictionary<string, Delegate>();
                dico["AvainPBinvTaskulamppuPBinv"] = new Func<string, string>(Func1);
                dico["TaskulamppuPBinvAvainPBinv"] = new Func<string, string>(Func1);
                dico["AvainPBinvOviKiinniPB"] = new Func<string, string>(Func2);
                dico[""] = new Func<string, string>(Func3);
                dico[""] = new Func<string, string>(Func5);
                dico[""] = new Func<string, string>(Func6);
                dico[""] = new Func<string, string>(Func7);
                dico[""] = new Func<string, string>(Func8);
                dico[""] = new Func<string, string>(Func9);
                dico[""] = new Func<string, string>(Func10);
                // and later invoke
                var res = dico[yhdistetty].DynamicInvoke(yhdistetty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mitään mielenkiintoista ei tapahtunut.");
                lisaa = null;
            }

            return lisaa;
        }


       

        private string Func1(string arg)
        {


            MessageBox.Show("tarvitset vielä jesaria että voit laittaa avaimen lamppuun kiinni.");
            

            return null;
        }

        private string Func2(string arg)
        {
            lisaa.Add("OviAukiPB");
            lisaa.Add("_");
            lisaa.Add("OviKiinniPB");
            lisaa.Add("AvainPBinv");
            lisaa.Add("LappuPB");
            return null;
        }
        private string Func3(string arg)
        {
            
            return null;
        }
        private string Func4(string arg)
        {
            
            return null;
        }
        private string Func5(string arg)
        {
            
            return null;
        }
        private string Func6(string arg)
        {
           
            return null;
        }
        private string Func7(string arg)
        {
            
            return null;
        }
        private string Func8(string arg)
        {
           
            return null;
        }
        private string Func9(string arg)
        {
            
            return null;
        }
        private string Func10(string arg)
        {
            
            return null;
        }
        private string Func11(string arg)
        {
            return null;
        }
    }
}
