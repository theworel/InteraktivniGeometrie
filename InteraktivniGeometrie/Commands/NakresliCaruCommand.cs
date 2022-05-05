using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    class NakresliCaruCommand : Command
    {
        public void exec(string[] args, Nakresna n)
        {
            string jmeno = args[args.Length-1];
            for(int i = 0; i<args.Length; i++)
            {
                Console.WriteLine(i + ": " + args[i]);
            }
            string[] jmenaBodu = new string[args.Length - 1];
            Array.ConstrainedCopy(args, 0, jmenaBodu, 0, args.Length - 1);
            Console.WriteLine(jmeno);
            n.pridejCaru(jmeno, jmenaBodu);
        }

        public string getName()
        {
            return "PridejCaru";
        }
    }
}
