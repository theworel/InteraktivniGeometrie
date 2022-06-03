using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie //část elipsy vepsané obdélníku určeném body stred (průsecík úhlopříček), top (stred jedné ze stran) a right (stred strany kolmé ke straně se středem top)
                                //startAngle 0 : úsecka (stred, right)
{
    class Oblouk : Cara
    {
        private float startAngle, sweepAngle;
        private Bod stred, top, right; 

        public Oblouk(Bod top, Bod right, Bod stred, float startAngle, float sweepAngle)
        {
            this.top = top;
            this.right = right;
            this.stred = stred;
            Console.WriteLine("konstruktor oblouku");
            Console.WriteLine("top: " + top.getSouradnice()[0] + " " + top.getSouradnice()[1]);
            Console.WriteLine("right: " + right.getSouradnice()[0] + " " + right.getSouradnice()[1]);
            Console.WriteLine("stred: " + stred.getSouradnice()[0] + " " + stred.getSouradnice()[1]);
            this.startAngle = startAngle;
            this.sweepAngle = sweepAngle;
        }
        public void vykresliSe(Vektor vektorX, Vektor vektorY, Vektor vektorPosun, Nakresna n)
        {
            System.Drawing.Graphics g = n.getG();

            Console.WriteLine("top: " + top.projekceDo2D(vektorX, vektorY)[0] + " " + top.projekceDo2D(vektorX, vektorY)[1]);
            Console.WriteLine("right: " + right.projekceDo2D(vektorX, vektorY)[0] + " " + right.projekceDo2D(vektorX, vektorY)[1]);
            Console.WriteLine("stred: " + stred.projekceDo2D(vektorX, vektorY)[0] + " " + stred.projekceDo2D(vektorX, vektorY)[1]);
            PointF projekceTop = new PointF(top.projekceDo2D(vektorX, vektorY)[0] + vektorPosun.getSouradnice()[0], top.projekceDo2D(vektorX, vektorY)[1] + vektorPosun.getSouradnice()[1]);
            PointF projekceRight = new PointF(right.projekceDo2D(vektorX, vektorY)[0] + vektorPosun.getSouradnice()[0], right.projekceDo2D(vektorX, vektorY)[1] + vektorPosun.getSouradnice()[1]);
            PointF projekceStred = new PointF(stred.projekceDo2D(vektorX, vektorY)[0] + vektorPosun.getSouradnice()[0], stred.projekceDo2D(vektorX, vektorY)[1] + vektorPosun.getSouradnice()[1]);
            float width = (float) Math.Sqrt((projekceRight.X - projekceStred.X)* (projekceRight.X - projekceStred.X) + (projekceRight.Y - projekceStred.Y) *(projekceRight.Y - projekceStred.Y))* 2;
            float height = (float) Math.Sqrt((projekceTop.X - projekceStred.X) * (projekceTop.X - projekceStred.X) + (projekceTop.Y - projekceStred.Y) * (projekceTop.Y - projekceStred.Y)) * 2;
            //float uhel = ((projekceRight.X - projekceStred.X) * vektorX.getSouradnice()[0] + (projekceRight.Y - projekceStred.Y) * vektorX.getSouradnice()[1]); //skalarni soucin vektoru osy elipsy a vektoruX nakresny

            Console.WriteLine("projekceTop: " + projekceTop.X + " " + projekceTop.Y);
            Console.WriteLine("projekceRight: " + projekceRight.X + " " + projekceRight.Y);
            Console.WriteLine("projekceStred: " + projekceStred.X + " " + projekceStred.Y);
            float uhel = (projekceRight.X - projekceStred.X);
            Console.WriteLine("úhel: " + uhel);
            uhel /= vektorX.getDelka();
            Console.WriteLine(uhel);
            uhel /= (float)Math.Sqrt((projekceRight.X - projekceStred.X) * (projekceRight.X - projekceStred.X) + (projekceRight.Y - projekceStred.Y) * (projekceRight.Y - projekceStred.Y));
            Console.WriteLine("acos(" + uhel);
            uhel = (float) Math.Acos(uhel) * 180/ (float) Math.PI;
            Console.WriteLine("velikost uhlu: " + uhel);
            try
            {
                g.TranslateTransform(projekceStred.X, projekceStred.Y);
                
                g.RotateTransform(uhel);
                g.TranslateTransform(-projekceStred.X, -projekceStred.Y);
            }catch(ArgumentException e)
            {
                Console.WriteLine(uhel);
            }
            g.DrawArc(Pens.Black, projekceStred.X -width/2, projekceStred.Y - height/2, width, height, startAngle, sweepAngle);
            try
            {
                g.TranslateTransform(projekceStred.X, projekceStred.Y);
                g.RotateTransform(-uhel);
                g.TranslateTransform(-projekceStred.X, -projekceStred.Y);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(-uhel);
            }
            
        }

        public Bod getStred()
        {
            return this.stred;
        }
    }
}
