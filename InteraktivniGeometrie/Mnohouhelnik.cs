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
            PrimaCara[] ret = new PrimaCara[body.Length];
            for(int i=0; i<body.Length-1; i++)
            {
                ret[i] = new PrimaCara(body[i], body[i + 1]);
            }
            ret[body.Length - 1] = new PrimaCara(body[0], body.Last());
            return ret;
        }

        public float[] poziceJmena(float[,] vektory)
        {
            float[] ret = new float[] { 0, 0 };
            foreach(Bod b in body)
            {
                ret[0] += b.projekceDo2D(new float[] { vektory[0, 0], vektory[0, 1] }, new float[] { vektory[1, 0], vektory[1, 1] })[0];
                ret[1] += b.projekceDo2D(new float[] { vektory[0, 0], vektory[0, 1] }, new float[] { vektory[1, 0], vektory[1, 1] })[1];
                Console.WriteLine(ret[0]);
                Console.WriteLine(ret[1]);
            }

            ret[0] /= this.body.Length;
            ret[1] /= this.body.Length;
            
            Console.WriteLine(ret[0]);
            Console.WriteLine(ret[1]);
            return ret;
        }
    }
}
