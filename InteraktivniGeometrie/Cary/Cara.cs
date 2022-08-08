using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    public interface Cara
    {
        //void vykresliSe(float[,] vektory, Nakresna n, out float[] poziceJmena);
        void vykresliSe(Vektor vektorX, Vektor vektorY, Vektor vektorPosun,  Nakresna n);
        void vykresliSeSBarvou(Vektor vektorX, Vektor vektorY, Vektor vektorPosun, Nakresna n, System.Drawing.Pen b);
        Bod getStred();
        //string getName();
    }
}
