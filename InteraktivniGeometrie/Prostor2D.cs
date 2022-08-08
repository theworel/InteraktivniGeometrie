using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    class Prostor2D : Prostor
    {

        private List<Bod> body;
        private List<Tvar> tvary;
        private List<Tuple<Bod,List<Tvar>>> prislusnosti;
        public Prostor2D()
        {
            this.body = new List<Bod>();
            this.tvary = new List<Tvar>();
            this.prislusnosti = new List<Tuple<Bod, List<Tvar>>>();
        }

        public Vektor[] kanonickaBaze()
        {
            return new Vektor2D[] { new Vektor2D(1, 0), new Vektor2D(0, 1) };
        }

        public void pridejBod(Bod b)
        {
            if (b.getSouradnice().Length == 2)
            {
                body.Add(b);
                prislusnosti.Add(new Tuple<Bod, List<Tvar>>(b, new List<Tvar>()));
            }
            else
                Console.WriteLine("neplatné zadání bodu - špatný počet souřadnic pro daný prostor");
        }

        /*public void pridejCaru(Cara c)
        {
            this.tvary.Add(c);
        }*/

        public void pridejTvar(Tvar t)
        {
            this.tvary.Add(t);
            foreach(Bod b in t.klicoveBody()){
                foreach (Tuple<Bod, List<Tvar>> tup in prislusnosti)
                {
                    if (tup.Item1.Equals(b))
                        tup.Item2.Add(t);

                }
            }
        }

        public Tvar[] tvarySTimtoBodem(Bod b)
        {
            

            foreach(Tuple<Bod,List<Tvar>> t in prislusnosti)
            {
                if (t.Item1.Equals(b))
                    return t.Item2.ToArray();

            }

            throw new BodNeexistujeException();
        }

        public Bod[] vsechnyBody()
        {
            return body.ToArray();
        }

        public Tvar[] vsechnyTvary()
        {
            return this.tvary.ToArray();
        }

        public void odeberBod(Bod b)
        {
            foreach(Tvar t in tvarySTimtoBodem(b))
            {
                odeberTvar(t);
            }
            this.body.Remove(b);
        }

        public void odeberTvar(Tvar t)
        {
            this.tvary.Remove(t);
        }
    }
}
