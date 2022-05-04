using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    public interface Vektor
    {
        
        Vektor projekceNa(Vektor druhy);
        Vektor pricti(Vektor druhy);
        float skalarniSoucin(Vektor druhy);
        Bod posun(Bod posouvany);
        float getDelka();
        float[] getSouradnice();
        Vektor skaluj(float alpha);
        Bod prusecikS(Vektor druhy, Bod pocatek1, Bod pocatek2);
        Vektor nakolmiK(Vektor druhy);
        float getUhel(Vektor druhy);
        void otoc(Vektor druhyVektor, float uhel);
        
    }
}
