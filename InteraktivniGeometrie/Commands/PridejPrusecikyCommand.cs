using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie.Commands
{
    class PridejPrusecikyCommand : Command
    {
        public void exec(string[] args, Nakresna n)
        {
            n.pridejPruseciky(args[0], args[1]);
        }

        public string getName()
        {
            return "PridejPruseciky";
        }
    }
}
