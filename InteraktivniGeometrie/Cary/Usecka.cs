using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace InteraktivniGeometrie
{
    public class Usecka : Cara
    {
        private Bod b1, b2;
        public Usecka(Bod b1, Bod b2)
        {
            this.b1 = b1;
            this.b2 = b2;
        }

        public Bod getStred()
        {
            return b1.stredUsecky(b2);
        }

        public Bod[] prusecikyS(Cara druha)
        {
            if (druha is Usecka)
            {

                Vektor v = ((Usecka)druha).getVektor();

                Bod b = getVektor().prusecikS(v, b1, druha.getStred());
                if (obsahujeBod(b) && druha.obsahujeBod(b))
                {
                    return new Bod[] { b };
                }
                return new Bod[] { };
            }
            else
            {
                Bod[] kandidati =  getVektor().prusecikySElipsou(b1, druha.rovnice());

                List<Bod> pruseciky = new List<Bod>();

                foreach (Bod kandidat in kandidati)
                {
                    bool prvni = obsahujeBod(kandidat);
                    bool d = druha.obsahujeBod(kandidat);
                    if(obsahujeBod(kandidat) && druha.obsahujeBod(kandidat))
                    {
                        pruseciky.Add(kandidat);
                    }
                }
                return pruseciky.ToArray();
            }
        }

        public bool obsahujeBod(Bod kandidat)
        {
           return ((kandidat.getSouradnice()[0] >= Math.Min(b1.getSouradnice()[0], b2.getSouradnice()[0])) && (kandidat.getSouradnice()[0] <= Math.Max(b1.getSouradnice()[0], b2.getSouradnice()[0]))
                && (kandidat.getSouradnice()[1] >= Math.Min(b1.getSouradnice()[1], b2.getSouradnice()[1])) && (kandidat.getSouradnice()[1] <= Math.Max(b1.getSouradnice()[1], b2.getSouradnice()[1])));
        }

        public Vektor getVektor()
        {
            return new Vektor2D(b1, b2);
        }
        public float[] rovnice()
        {
            

            float smernice = (b2.getSouradnice()[1] - b1.getSouradnice()[1]) / (b2.getSouradnice()[0] - b1.getSouradnice()[0]);
            return new float[] { smernice, b1.getSouradnice()[1] };

        }

        public void vykresliSe(Vektor vektorX, Vektor vektorY, Vektor vektorPosun, Nakresna n)
        {
            System.Drawing.Graphics g = n.getG();
            PointF p1 = new PointF(b1.projekceDo2D(vektorX, vektorY)[0] + vektorPosun.getSouradnice()[0], b1.projekceDo2D(vektorX, vektorY)[1] + vektorPosun.getSouradnice()[1]);
            PointF p2 = new PointF(b2.projekceDo2D(vektorX, vektorY)[0] + vektorPosun.getSouradnice()[0], b2.projekceDo2D(vektorX, vektorY)[1] + vektorPosun.getSouradnice()[1]);
            g.DrawLine(System.Drawing.Pens.Black, p1, p2);
        }

        public void vykresliSeSBarvou(Vektor vektorX, Vektor vektorY, Vektor vektorPosun, Nakresna n, Pen b)
        {
            System.Drawing.Graphics g = n.getG();
            PointF p1 = new PointF(b1.projekceDo2D(vektorX, vektorY)[0] + vektorPosun.getSouradnice()[0], b1.projekceDo2D(vektorX, vektorY)[1] + vektorPosun.getSouradnice()[1]);
            PointF p2 = new PointF(b2.projekceDo2D(vektorX, vektorY)[0] + vektorPosun.getSouradnice()[0], b2.projekceDo2D(vektorX, vektorY)[1] + vektorPosun.getSouradnice()[1]);
            g.DrawLine(b, p1, p2);
        }

        public float[] yPodleRovnice(float x)
        {
            throw new NotImplementedException();
        }
    }
}
