using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    class PridejObloukCommand : Command
    {
        public void exec(string[] args, Nakresna n)
        {
            string jmeno = args.Last();
            string[] oblouky = new string[args.Length - 1];
            if (oblouky.Length % 5 != 0)
            {
                foreach(String a in args)
                {
                    Console.WriteLine(a);
                }
                throw new SpatneArgumentyPrikazuException();
            }
            if (oblouky.Length == 5)
            {
                Array.ConstrainedCopy(args, 0, oblouky, 0, args.Length - 1);
                n.pridejOblouky(jmeno, oblouky);
            }
           
        }

        public string getName()
        {
            return "PridejOblouk";
        }
    }
}
