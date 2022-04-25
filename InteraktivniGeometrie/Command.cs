using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    interface Command
    {
        String getName();
        void exec(String[] args, Nakresna n);
    }
}
