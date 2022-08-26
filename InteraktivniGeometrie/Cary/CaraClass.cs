using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie.Cary
{
    public abstract class CaraClass : Cara
    {
        public abstract Bod getStred();
        public abstract Bod[] prusecikyS(Cara druha);
        public abstract float[] rovniceFunkce();
        public abstract void vykresliSe(Vektor vektorX, Vektor vektorY, Vektor vektorPosun, Nakresna n);
        public abstract void vykresliSeSBarvou(Vektor vektorX, Vektor vektorY, Vektor vektorPosun, Nakresna n, Pen b);
        public abstract float[] yPodleRovnice(float x);
        public float[] vyresKvadratickouRovnici(float[] rovnice)
        {
            return new float[] { 0 };
        }
    }
}
