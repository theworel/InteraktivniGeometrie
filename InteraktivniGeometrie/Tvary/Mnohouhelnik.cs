using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    /**
     * Třída reprezentující mnohoúhelník definovaný body pospojovanými úsečkami v takovém pořadí, v jakém jsou zadány
     * **/

    class Mnohouhelnik : Tvar
    {
        private string name;
        private Bod[] body;

        public Mnohouhelnik(string name, params Bod[] body)
        {
            this.name = name;
            this.body = body;
        }
        public string getName()
        {
            return this.name;
        }

        public Bod[] klicoveBody()
        {
            return this.body;
        }

        public Cara[] klicoveCary()
        {
            Usecka[] ret = new Usecka[body.Length];
            for(int i=0; i<body.Length-1; i++)
            {
                ret[i] = new Usecka(body[i], body[i + 1]);
            }
            ret[body.Length - 1] = new Usecka(body[0], body.Last());
            return ret;
        }

        public float[] poziceJmena(Vektor vektorX, Vektor vektorY)
        {
            float[] ret = new float[] { 0, 0 };
            foreach(Bod b in body)
            {
                ret[0] += b.projekceDo2D(vektorX, vektorY)[0];
                ret[1] += b.projekceDo2D(vektorX, vektorY)[1];
                
            }

            ret[0] /= this.body.Length;
            ret[1] /= this.body.Length;
            
            
            return ret;
        }

        public string getCommand()
        {
            string[] names = new string[body.Length+1];
            int i = 0;
            foreach (Bod b in body) {
                names[i] = b.getName();
                i++;
            }
            names[body.Length] = this.getName();
            return string.Join(" ", "PridejMnohouhelnik", names);
        }
    }
}
