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
        List<string> poista = new List<string>();
        public List<string> Lisaa { get; set; }
        public List<string> Poista { get; set; }
        public void UseItem(string juttu)
        {
            // store
            var dico = new Dictionary<string, Delegate>();
            dico["AvainPBinvTaskulamppuPBinv"] = new Func<string, string>(Func1);
            dico[""] = new Func<string, string>(Func2);
            dico[""] = new Func<string, string>(Func3);
            dico[""] = new Func<string, string>(Func4);
            dico[""] = new Func<string, string>(Func5);
            dico[""] = new Func<string, string>(Func6);
            dico[""] = new Func<string, string>(Func7);
            dico[""] = new Func<string, string>(Func8);
            dico[""] = new Func<string, string>(Func9);
            dico[""] = new Func<string, string>(Func10);
            // and later invoke
            var res = dico[juttu].DynamicInvoke(juttu);
            
        }


       

        private string Func1(string arg)
        {
            lisaa.Clear();
            
            lisaa.Add("AvainPB.Visible");
            lisaa.Add("AvainPBinv");
            MessageBox.Show(lisaa.Count.ToString());
            return null;
        }

        private string Func2(string arg)
        {
            
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
