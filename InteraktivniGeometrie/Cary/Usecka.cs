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

        public void vykresliSe(Vektor vektorX, Vektor vektorY, Vektor vektorPosun, Nakresna n)
        {
            System.Drawing.Graphics g = n.getG();
            PointF p1 = new PointF(b1.projekceDo2D(vektorX, vektorY)[0] + vektorPosun.getSouradnice()[0], b1.projekceDo2D(vektorX, vektorY)[1] + vektorPosun.getSouradnice()[1]);
            PointF p2 = new PointF(b2.projekceDo2D(vektorX, vektorY)[0] + vektorPosun.getSouradnice()[0], b2.projekceDo2D(vektorX, vektorY)[1] + vektorPosun.getSouradnice()[1]);
            g.DrawLine(System.Drawing.Pens.Black, p1, p2);
        }
    }
}
