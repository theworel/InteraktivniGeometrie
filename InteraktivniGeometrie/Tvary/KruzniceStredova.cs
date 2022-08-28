using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie.Tvary
{
    class KruzniceStredova : Tvar
    {
        private string name;
        private Bod stred;
        private Bod druhy;
        private Vektor kolmySmer, vodorovnySmer;
        public string getName()
        {
            return this.name;
        }

        public KruzniceStredova(Bod stred, Bod dalsi, Vektor kolmySmer, Vektor vodorovnySmer, string jmeno)
        {
            this.stred = stred;
            this.druhy = dalsi;
            this.kolmySmer = kolmySmer;
            this.vodorovnySmer = vodorovnySmer;
            this.name = jmeno;
        }

        public Bod[] klicoveBody()
        {
            return new Bod[] { stred, druhy };
        }

        public Cara[] klicoveCary()
        {
            Vektor polomer = stred.vektorNaBod(druhy);
            Vektor polomer2;
            if (Math.Abs(polomer.getUhel(kolmySmer))>0.01)
                polomer2 = kolmySmer.nakolmiK(polomer);
            else
                polomer2 = vodorovnySmer.nakolmiK(polomer);

            float r = polomer.getDelka();
            float normalizer = r * r - stred.getSouradnice()[1] * stred.getSouradnice()[1] - stred.getSouradnice()[0] * stred.getSouradnice()[0];
            return new Cara[] { new Oblouk(polomer.posun(stred), polomer2.skaluj(polomer.getDelka() / polomer2.getDelka()).posun(stred), stred, 0, 360, new float[] { 1 / normalizer, 0, 1 / normalizer,  -2 * stred.getSouradnice()[0] / normalizer, -2 * stred.getSouradnice()[1] / normalizer }) };


        }

        public float[] poziceJmena(Vektor vektorX, Vektor vektorY)
        {
            return stred.projekceDo2D(vektorX, vektorY);
        }
    }
}
