using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    class Oblouky_tvar : Tvar
    {
        public string name;
        public Cara[] cary;

        public Oblouky_tvar(string name, Cara[] oblouky)
        {
            this.name = name;
            this.cary = oblouky;
        }

        public string getName()
        {
            return this.name;
        }

        public Bod[] klicoveBody()
        {
            return new Bod[] { };
        }

        public Cara[] klicoveCary()
        {
            return this.cary;
        }

        public float[] poziceJmena(Vektor vektorX, Vektor vektorY)
        {
            float[] ret = new float[] { 0, 0 };
            foreach (Cara c in cary)
            {
                ret[0] += c.getStred().projekceDo2D(vektorX, vektorY)[0];
                ret[1] += c.getStred().projekceDo2D(vektorX, vektorY)[1];
                Console.WriteLine(ret[0]);
                Console.WriteLine(ret[1]);
            }

            ret[0] /= this.cary.Length;
            ret[1] /= this.cary.Length;

            Console.WriteLine(ret[0]);
            Console.WriteLine(ret[1]);
            
            return ret;
        }
    }
}
