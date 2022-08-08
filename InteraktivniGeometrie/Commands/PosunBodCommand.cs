using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie.Commands
{
    class PosunBodCommand : Command
    {
        public void exec(string[] args, Nakresna n)
        {
            string jmenoBodu = args.Last();
            float xposun = float.Parse(args[0]);
            float yposun = float.Parse(args[1]);

            n.vyberBod(jmenoBodu);
            n.posunVybranyBod(xposun, yposun);
        }

        public string getName()
        {
            return "PosunBod";
        }
    }
}
