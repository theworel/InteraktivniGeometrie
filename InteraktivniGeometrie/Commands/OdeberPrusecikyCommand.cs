using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie.Commands
{
    class OdeberPrusecikyCommand : Command
    {
        public void exec(string[] args, Nakresna n)
        {
            n.odeberPruseciky(new Tuple<string, string>(args[0], args[1]));
        }

        public string getName()
        {
            return "OdeberPruseciky";
        }
    }
}
