using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    class Prostor2D : Prostor
    {
        private int pocetPruseciku;
        private List<Bod> body;
        private List<Tvar> tvary;
        private Dictionary<Bod,List<Tvar>> prislusnosti;
       
        private Dictionary<Tvar, List<Bod>> prusecikyTvaru;
        public Prostor2D()
        {
            this.body = new List<Bod>();
            this.tvary = new List<Tvar>();
            this.prislusnosti = new Dictionary<Bod, List<Tvar>>();
            this.prusecikyTvaru = new Dictionary<Tvar, List<Bod>>();
            this.pocetPruseciku = 0;
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
                prislusnosti.Add(b, new List<Tvar>());
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
                prislusnosti[b].Add(t);
            }
            prusecikyTvaru.Add(t, new List<Bod>());
        }

        public Tvar[] tvarySTimtoBodem(Bod b)
        {


            List<Tvar> ret = new List<Tvar>();
            if (prislusnosti.TryGetValue(b, out ret))
                return ret.ToArray();

            throw new BodNeexistujeException();
        }

        public Bod[] bodyZavisleNaTvaru(Tvar tvar)
        {
            List<Bod> ret = new List<Bod>();
            if (prusecikyTvaru.TryGetValue(tvar,out ret))
                return ret.ToArray();

            throw new Exception();
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
            foreach(Bod b in bodyZavisleNaTvaru(t))
            {
                odeberBod(b);
            }
            this.tvary.Remove(t);
        }

        public void pridejPrusecikyTvaru(Tvar t1, Tvar t2)
        {


        foreach (Bod prusecik in this.najdiPrusecikyTvaru(t1, t2))
              {
                 Bod pojmenovany = new Bod2D(prusecik.getSouradnice()[0], prusecik.getSouradnice()[1], true, pocetPruseciku);
                 this.pridejBod(pojmenovany);
                 prusecikyTvaru[t1].Add(pojmenovany);
                 prusecikyTvaru[t2].Add(pojmenovany);
                 pocetPruseciku++;
              }
                
            
        }

        public Bod[] vsechnyVolneBody()
        {
            List<Bod> ret = new List<Bod>();
            foreach (Bod b in this.body)
            {
                if (!b.jePrusecik())
                    ret.Add(b);
            }
            return ret.ToArray();
        }

        public Bod[] najdiPrusecikyTvaru(Tvar tvar1, Tvar tvar2)
        {
            List<Bod> pruseciky = new List<Bod>();
            foreach (Cara c in tvar1.klicoveCary())
            {
                foreach (Cara d in tvar2.klicoveCary())
                {
                    Bod[] prusecikyCar = c.prusecikyS(d);
                    foreach (Bod prusecik in prusecikyCar)
                    {
                        pruseciky.Add(prusecik);
                    }
                }
            }
            return pruseciky.ToArray();
        }
    }
}
