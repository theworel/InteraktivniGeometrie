using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    public interface Bod
    {
        float[] getSouradnice();
        float[] projekceDo2D(float[] vektorX, float[] vektorY);
        float[] projekceDo3D(float[] vektorX, float[] vektorY, float[] vektorZ);
        string getName();
    }
}
