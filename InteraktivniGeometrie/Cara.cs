using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    public interface Cara : Tvar
    {
        void vykresliSe(float[,] vektory, Nakresna n, out float[] poziceJmena);
        void vykresliSe(float[,] vektory, Nakresna n);
        string getName();
    }
}
