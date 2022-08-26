using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie.Commands
{
    class PridejEliptickyObloukCommand : Command
    {
        public void exec(string[] args, Nakresna n)
        {
            string jmeno = args[args.Length - 1];

            string[] jmenaBodu = new string[args.Length - 1];
            Array.ConstrainedCopy(args, 0, jmenaBodu, 0, args.Length - 1);
            if (jmenaBodu.Length == 4 || jmenaBodu.Length == 3) { 
                n.pridejEliptickyOblouk(jmeno, jmenaBodu);
                return;
            }
            
        }

        public string getName()
        {
            return "PridejEliptickyOblouk";
        }
    }
}
