﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    public interface Bod
    {
        float[] getSouradnice();
        float[] projekceDo2D(Vektor vektorX, Vektor vektorY);
        float[] projekceDo3D(Vektor vektorX, Vektor vektorY, Vektor vektorZ);
        string getName();
        void posun(Vektor vPosun);
        bool jeStejnyJako(Bod druhy);
        float vzdalenostOd(Bod b);
        Bod stredUsecky(Bod druhy);
        Vektor vektorNaBod(Bod konec);
        Bod projekceNaPrimku(Bod pocatek, Vektor vektorX);
        bool jePrusecik();
    }
}
