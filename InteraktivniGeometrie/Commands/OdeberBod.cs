using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie.Commands
{
    class OdeberBod : Command
    {
        public void exec(string[] args, Nakresna n)
        {
            n.odeberBod(args[0]);
        }

        public string getName()
        {
            return "OdeberBod";
        }
    }
}
