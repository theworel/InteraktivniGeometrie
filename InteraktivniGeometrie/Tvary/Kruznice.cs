using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    class Kruznice : Tvar
    {
        private string name;
        private Bod[] Body;
        private Cara[] Cary;
       

        public Kruznice(Bod b1, Bod b2, Bod b3, string name)
        {
            this.name = name;
            this.Body = new Bod[] { b1, b2, b3 };
            if(Body.Distinct().Count() != Body.Length)
            {
                throw new InteraktivniGeometrie.Exceptions.NemoznyTvarException();
            }
        }

        public string getCommand()
        {
            return "pridejKruznici " + string.Join(" ", Body[0].getName(), Body[1].getName(), Body[2].getName(), this.getName());
        }
        
        public string getName()
        {
            return this.name;
        }

        public Bod[] klicoveBody()
        {
            return this.Body;
        }

        public Cara[] klicoveCary()
        {
            Bod stredB1B2 = this.Body[0].stredUsecky(this.Body[1]);
            Bod stredB1B3 = this.Body[0].stredUsecky(this.Body[2]);



            Vektor vB1B2 = this.Body[0].vektorNaBod(this.Body[1]);
            Vektor vB1B3 = this.Body[0].vektorNaBod(this.Body[2]);

            Vektor vektorOsyB1B2 = vB1B3.nakolmiK(vB1B2);
            Vektor vektorOsyB1B3 = vB1B2.nakolmiK(vB1B3);

            Bod stred = vektorOsyB1B2.prusecikS(vektorOsyB1B3, stredB1B2, stredB1B3);

            

            Vektor polomer1 = stred.vektorNaBod(this.Body[0]);
            Vektor polomer2 = stred.vektorNaBod(this.Body[1]).nakolmiK(polomer1);
            polomer2 = polomer2.skaluj(polomer1.getDelka() / polomer2.getDelka());
            float r = polomer1.getDelka();

            if (float.IsNaN(r))
            {
                return new Cara[0];
            }
            //rovnice kruynice: (x-s1)^2 + (y-s2)^2 = r^2
            //xx - 2xs1 + s1^2 + yy -2ys2 + s2^2 - r^2 = 0
            //xx + yy + 0xy -2s1 *x - 2s2*y  = r^2
            //xx/r^2 + yy/r^2 - 2s1/r^2
            float normalizer = r * r - stred.getSouradnice()[1] * stred.getSouradnice()[1] - stred.getSouradnice()[0] * stred.getSouradnice()[0];
            this.Cary = new Cara[] { new Oblouk(polomer1.posun(stred), polomer2.posun(stred), stred, 0, 360, new float[] {1/normalizer,0, 1 / normalizer, -2*stred.getSouradnice()[0]/(normalizer), -2 * stred.getSouradnice()[1] / (normalizer) }) };
            return this.Cary;
        }

        public float[] poziceJmena(Vektor vektorX, Vektor vektorY)
        {

            Bod stredB1B2 = this.Body[0].stredUsecky(this.Body[1]);
            Bod stredB1B3 = this.Body[0].stredUsecky(this.Body[2]);

            Vektor vB1B2 = this.Body[0].vektorNaBod(this.Body[1]);
            Vektor vB1B3 = this.Body[0].vektorNaBod(this.Body[2]);

            Vektor vektorOsyB1B2 = vB1B3.nakolmiK(vB1B2);
            Vektor vektorOsyB1B3 = vB1B2.nakolmiK(vB1B3);

            Bod stred = vektorOsyB1B2.prusecikS(vektorOsyB1B3, stredB1B2, stredB1B3);
            return stred.projekceDo2D(vektorX,
                vektorY);
        }
    }
}
