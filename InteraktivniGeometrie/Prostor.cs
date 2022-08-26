using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    interface Prostor
    {
        Bod[] vsechnyBody();
        Tvar[] vsechnyTvary();
        void pridejBod(Bod b);
        //void pridejCaru(Cara c);
        void pridejTvar(Tvar t);
        Vektor[] kanonickaBaze();
        Tvar[] tvarySTimtoBodem(Bod b);
        void odeberBod(Bod b);
        void odeberTvar(Tvar t);
        void pridejPrusecikyTvaru(Tvar t1, Tvar t2);
        Bod[] vsechnyVolneBody();
    }
}
