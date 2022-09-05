using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie.Commands
{
    class OdeberTvar : Command
    {
        public void exec(string[] args, Nakresna n)
        {
            n.odeberTvar(args[0]);
        }

        public string getName()
        {
            return "OdeberTvar";
        }
    }
}
