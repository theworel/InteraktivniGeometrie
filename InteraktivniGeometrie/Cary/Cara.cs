﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    public interface Cara
    {
        
        void vykresliSe(Vektor vektorX, Vektor vektorY, Vektor vektorPosun, Nakresna n);
        void vykresliSeSBarvou(Vektor vektorX, Vektor vektorY, Vektor vektorPosun, Nakresna n, System.Drawing.Pen b);
        Bod getStred();
        Bod[] prusecikyS(Cara druha);
        float[] rovnice();
        float[] yPodleRovnice(float x);
        bool obsahujeBod(Bod kandidat);
        
    }
}
