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

            n.pridejEliptickyOblouk(jmeno, jmenaBodu);
        }

        public string getName()
        {
            return "pridejEliptickyOblouk";
        }
    }
}
