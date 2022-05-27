using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscapeRoom
{
    internal class Kerattavat
    {
        public void PickUp(string juttu)
        {
            // store
            var dico = new Dictionary<string, Delegate>();
            dico["ReppuPB"] = new Func<string, string>(Func1);
            dico["TakkiPB"] = new Func<string, string>(Func2);
            dico["KengatPB"] = new Func<string, string>(Func3);
            dico["HuiviPB"] = new Func<string, string>(Func4);
            dico["TaskulamppuPB"] = new Func<string, string>(Func5);
            dico["MankkaPB"] = new Func<string, string>(Func6);
            dico["SprayPB"] = new Func<string, string>(Func7);
            dico["SipsiPB"] = new Func<string, string>(Func8);
            dico["EsPB"] = new Func<string, string>(Func9);
            dico["AvainPB"] = new Func<string, string>(Func10);

            // and later invoke
            var res = dico[juttu].DynamicInvoke(juttu);
        }

        
         //Esimerkki funktio mihin voi laittaa haluamansa tekstin mikä tavara
         /*
          * 
        private string Func1(string arg)
        {
            MessageBox.Show("Tähän tulee teksti mikä tavara")
            return null;
        }

        */

        private string Func1(string arg)
        {
            MessageBox.Show("Otat reppusi jotta voit kerätä tarvitsemasi tavarat mukaan.");
            return null;
        }

        private string Func2(string arg)
        {
            MessageBox.Show("Laitat takin päälle jottei tule kylmä");
            return null;
        }
        private string Func3(string arg)
        {
            MessageBox.Show("Kengät jalkaan ja menoksi.");
            return null;
        }
        private string Func4(string arg)
        {
            MessageBox.Show("Mitenköhän huivini oli tänne päätynyt");
            return null;
        }
        private string Func5(string arg)
        {
            MessageBox.Show("Uusi super tehokas maagilite minkä sait joululahjaksi");
            return null;
        }
        private string Func6(string arg)
        {
            MessageBox.Show("Vanha mutta uskollinen poppikone. Sitä ilman ei voi lähteä minnekään.");
            return null;
        }
        private string Func7(string arg)
        {
            MessageBox.Show("Kilikali purkkeja. niille saattaa löytyä myöhemmin käyttöä.");
            return null;
        }
        private string Func8(string arg)
        {
            MessageBox.Show("Sipsuja pitää aina olla mukana!");
            return null;
        }
        private string Func9(string arg)
        {
            MessageBox.Show("Tänään päristään.");
            return null;
        }
        private string Func10(string arg)
        {
            MessageBox.Show("Avain kotioveen");
            return null;
        }
        private string Func11(string arg)
        {
            return null;
        }
    }
}
