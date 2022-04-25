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
        public Prostor2D()
        {
            this.body = new List<Bod>();
            this.tvary = new List<Tvar>();
        }
        public void pridejBod(Bod b)
        {
            if (b.getSouradnice().Length == 2)
                body.Add(b);
            else
                Console.WriteLine("neplatné zadání bodu - špatný počet souřadnic pro daný prostor");
        }

        public void pridejCaru(Cara c)
        {
            this.tvary.Add(c);
        }

        public void pridejTvar(Tvar t)
        {
            this.tvary.Add(t);
        }

        public Bod[] vsechnyBody()
        {
            return body.ToArray();
        }

        public Tvar[] vsechnyTvary()
        {
            return this.tvary.ToArray();
        }
    }
}
