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
       // private Mnohouhelnik ctverecOpsany;
       // private Bod stred;

        public Kruznice(Bod b1, Bod b2, Bod b3, string name)
        {
            this.Body = new Bod[] { b1, b2, b3 };
            //lin. kombinace s = a1* (b1 -b2)+ a2* (b1-b3), t.ž. (
            

            /*Bod stredB1B2 = b1.stredUsecky(b2);
            Bod stredB1B3 = b1.stredUsecky(b3);

           

            Vektor vB1B2 = b1.vektorNaBod(b2);
            Vektor vB1B3 = b1.vektorNaBod(b3);

            Vektor vektorOsyB1B2 = vB1B3.nakolmiK(vB1B2);
            Vektor vektorOsyB1B3 = vB1B2.nakolmiK(vB1B3);

            Bod stred = vektorOsyB1B2.prusecikS(vektorOsyB1B3, stredB1B2, stredB1B3);
            this.stred = stred;
            

            Vektor polomer1 = stred.vektorNaBod(b1);
            Vektor polomer2 = stred.vektorNaBod(b2).nakolmiK(polomer1);
            polomer2 = polomer2.skaluj(polomer1.getDelka()/polomer2.getDelka());

            

            this.Cary = new Cara[] { new Oblouk(polomer1.posun(stred), polomer2.posun(stred), stred, 0, 360) };*/
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



            this.Cary = new Cara[] { new Oblouk(polomer1.posun(stred), polomer2.posun(stred), stred, 0, 360) };
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
