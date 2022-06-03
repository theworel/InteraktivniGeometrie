using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    class PridejBodCommand : Command
    {
        public void exec(string[] args, Nakresna n)
        {
            if(args.Length == 3)
            {
                try
                {
                    n.pridejBod(new Bod2D(float.Parse(args[0]), float.Parse(args[1]), args[2]));
                }
                catch (FormatException)
                {
                    MessageBox.Show("Špatné zadání bodu");
                }
            }
        }

        public string getName()
        {
            return "PridejBod";
        }
    }
}
