using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    public interface Tvar
    {
        
        Bod[] klicoveBody();
        Cara[] klicoveCary();
        string getName();
        float[] poziceJmena(Vektor vektorX, Vektor vektorY);
        string getCommand();
    }
}
