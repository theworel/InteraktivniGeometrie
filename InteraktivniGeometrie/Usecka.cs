using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    class Usecka : PrimaCara
    {
        public Usecka(string name, params Bod[] body) : base(name, body)
        {
            if (body.Length != 2)
                throw new NeplatnaUseckaException();
        }

        
    }
}
