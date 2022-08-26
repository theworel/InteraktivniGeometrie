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

        static float stredovyUhel(Bod a, Bod b, Bod stred, Vektor osaDoprava, Vektor svislaOsa)
        {
            float ret = stred.vektorNaBod(a).getUhel(stred.vektorNaBod(b)) * 180 / (float)Math.PI;
            return ret;

            if (a.projekceNaPrimku(stred, osaDoprava).vzdalenostOd(b.projekceNaPrimku(stred, osaDoprava)) > a.projekceNaPrimku(stred, osaDoprava).vzdalenostOd(stred))//pokud A a B jsou v ruznych polkach elipsy podle svisle osy
            {
                if (a.projekceNaPrimku(stred, svislaOsa).vzdalenostOd(b.projekceNaPrimku(stred, svislaOsa)) > a.projekceNaPrimku(stred, svislaOsa).vzdalenostOd(stred))//A a B jsou v ruznych pulkach elipsy podle vodorovne osy, tedy v opacnych kvadrantech

                    ret = (stred.vektorNaBod(a).getUhel(stred.vektorNaBod(b)) * 180 / (float)Math.PI);
                else
                {
                    float uhelAsOsou = stred.vektorNaBod(a).getUhel(osaDoprava) * 180 / (float)Math.PI;
                    if (uhelAsOsou > 90)
                        uhelAsOsou = 180 - uhelAsOsou;

                    float uhelBsOsou = stred.vektorNaBod(b).getUhel(osaDoprava) * 180 / (float)Math.PI;
                    if (uhelBsOsou > 90)
                        uhelBsOsou = 180 - uhelBsOsou;
                    return 180 - (uhelAsOsou + uhelBsOsou);
                }
            }
            else
            {
                if (a.projekceNaPrimku(stred, svislaOsa).vzdalenostOd(b.projekceNaPrimku(stred, svislaOsa)) > a.projekceNaPrimku(stred, svislaOsa).vzdalenostOd(stred))
                {

                    float uhelAsOsou = stred.vektorNaBod(a).getUhel(osaDoprava) * 180 / (float)Math.PI;
                    if (uhelAsOsou > 90)
                        uhelAsOsou = 180 - uhelAsOsou;

                    float uhelBsOsou = stred.vektorNaBod(b).getUhel(osaDoprava) * 180 / (float)Math.PI;
                    if (uhelBsOsou > 90)
                        uhelBsOsou = 180 - uhelBsOsou;
                    return 180 - (uhelAsOsou + uhelBsOsou);
                }
                else
                    ret = stred.vektorNaBod(a).getUhel(stred.vektorNaBod(b)) * 180 / (float)Math.PI;
            }
            return ret;
        }


        private float startAngle, sweepAngle;
        private Bod stred, top, right;
        private float[] rovniceElipsy;
        private float delkaHlavniPoloosy;
        private float b;

        public Oblouk(Bod top, Bod right, Bod stred, float startAngle, float sweepAngle, float[] rovnice)
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
            this.rovniceElipsy = rovnice;

            this.delkaHlavniPoloosy = Math.Max(top.vzdalenostOd(stred), right.vzdalenostOd(stred));
            float delkaVedlejsiPoloosy = Math.Min((top.vzdalenostOd(stred), right.vzdalenostOd(stred));
            float e = 2 * (float)Math.Sqrt(delkaHlavniPoloosy * delkaHlavniPoloosy / 4 - delkaVedlejsiPoloosy * delkaVedlejsiPoloosy);
            this.b = (float)Math.Sqrt(delkaHlavniPoloosy * delkaHlavniPoloosy - e * e);
        }

        public float[] yPodleRovnice(float x)
        {
            float y1 = -rovniceElipsy[2] + (float)Math.Sqrt(x * x * (rovniceElipsy[2] * rovniceElipsy[2] - 4 * rovniceElipsy[1] * rovniceElipsy[0]) + x * (rovniceElipsy[2] * rovniceElipsy[4] - 4 * rovniceElipsy[1] * rovniceElipsy[3]) + rovniceElipsy[4] * rovniceElipsy[4] - 4 * rovniceElipsy[1] * rovniceElipsy[5]) / 2 * rovniceElipsy[1];
            float y2 = -rovniceElipsy[2] - (float)Math.Sqrt(x * x * (rovniceElipsy[2] * rovniceElipsy[2] - 4 * rovniceElipsy[1] * rovniceElipsy[0]) + x * (rovniceElipsy[2] * rovniceElipsy[4] - 4 * rovniceElipsy[1] * rovniceElipsy[3]) + rovniceElipsy[4] * rovniceElipsy[4] - 4 * rovniceElipsy[1] * rovniceElipsy[5]) / 2 * rovniceElipsy[1];
            return new float[] { y1, y2 };
        }

        public float getA()
        {
            return this.delkaHlavniPoloosy;
        }

        public float getB()
        {
            return this.b;
        }

        public Bod[] prusecikyS(Cara druha)
        {
            float[] vyjadriY = druha.rovnice();

            //this.rovnice je ve tvaru (r1*xx+r2*yy+r3xy+r4x+r5y+r6 = 0)
            //substituci r1*xx + (r2/4d2^2)[(xx*d3^2 - 2xd3(sqrt(xx*(d3^2 -4d2d1) + x(d3d5 - 4d2d4) + d5d5 - 4d2d6)) + xx(d3^2 - 4d2d1)) + x(d3d5 - 4d2d4) + d5^2 - 4d2d6)]+
            //          + r3x * ((-d3 + sqrt((xd3*xd3 + 2xd3d5 + d5*d5 - xx*4d2d1 - 4xd2d4 - 4d2d6)))/2d2 + r4x + r5((-xd3 + sqrt((xd3*xd3 + 2xd3d5 + d5*d5 - xx*4d2d1 - 4xd2d4 - 4d2d6)))/2d2 + r6 = 0

            //xx(r1 + d3^2r2/4d2^2 +d3^2 r2-4d2d1/4d2^2) + x(-d3r3 +r4-r5d3) + r6 - (2xd3r2/4d2^2-r3x-r5)*(sqrt(xx*(d3^2 -4d2d1) + x(d3d5 - 4d2d4) + d5d5 - 4d2d6))=0
            //xx(r1 + d3^2r2/4d2^2 +d3^2 r2-4d2d1/4d2^2) + x(-d3r3 +r4-r5d3) + r6 = (2xd3r2/4d2^2-r3x-r5)*(sqrt(xx*(d3^2 -4d2d1) + x(d3d5 - 4d2d4) + d5d5 - 4d2d6))

            if(druha is Usecka)
            {
                return druha.prusecikyS(this);
            }
            List<Bod> pruseciky = new List<Bod>();

            Vektor smerZkouseni = new Vektor2D(right, stred);
            Vektor vektorKolmice = new Vektor2D(stred, top);
            for (float i = 0; i < this.delkaHlavniPoloosy * 2; i += 0.1F)
            {

                smerZkouseni = smerZkouseni.skaluj(1 / smerZkouseni.getDelka());
                Bod kandidat1 = vektorKolmice.prusecikSElipsou(smerZkouseni.skaluj(i).posun(right), this.rovniceElipsy);
                Bod kandidat2 = vektorKolmice.skaluj(-1).prusecikSElipsou(smerZkouseni.skaluj(i).posun(right), this.rovniceElipsy);

                float[] ySouradniceDruhe = druha.yPodleRovnice(kandidat1.getSouradnice()[0]);
                if (Math.Abs(ySouradniceDruhe[0] - kandidat1.getSouradnice()[1]) < 0.01 || Math.Abs(ySouradniceDruhe[1] - kandidat1.getSouradnice()[1]) < 0.1)
                {
                    pruseciky.Add(kandidat1);
                }
                if (Math.Abs(ySouradniceDruhe[0] - kandidat2.getSouradnice()[1]) < 0.01 || Math.Abs(ySouradniceDruhe[1] - kandidat2.getSouradnice()[1]) < 0.1)
                {
                    pruseciky.Add(kandidat2);
                }

            }
                return pruseciky.ToArray();


        }

        /*public Bod[] prusecikyS(Oblouk druhy)
        {
            float
        }*/

        public float[] rovnice()
        {
            //rovnice je ve tvaru r1*xx+r2yy +r3xy+r4x+r5y+r6 = 0
            //chceme y = ...
            // r2(yy) + (xr3 + r5)*y + (xx*r1+xr4+r6)
            //y = (-(xr3) +- sqrt((xr3+r5)^2 - 4r2*(xx*r1+xr4+r6)))/2r2
            //y1 = (-xr3 + sqrt((xr3*xr3 + 2xr3r5 + r5*r5 - xx*4r2r1 - 4xr2r4 - 4r2r6)))/2r2
            //y1 = (-xr3 + sqrt((xx(r3r3 -4r2r1) + x(r3r5-4r2r4) +r5r5-4r2r6)/2r2 

            return rovniceElipsy;
        }

        public Bod getStred()
        {
            return this.stred;
        }

        public bool obsahujeBod(Bod kandidat)
        {
            float uhel = stredovyUhel(kandidat, right, stred, new Vektor2D(stred, top), new Vektor2D(stred, right));
            return (uhel > startAngle && uhel < sweepAngle);
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
            float width = (float)Math.Sqrt((projekceRight.X - projekceStred.X) * (projekceRight.X - projekceStred.X) + (projekceRight.Y - projekceStred.Y) * (projekceRight.Y - projekceStred.Y)) * 2;
            float height = (float)Math.Sqrt((projekceTop.X - projekceStred.X) * (projekceTop.X - projekceStred.X) + (projekceTop.Y - projekceStred.Y) * (projekceTop.Y - projekceStred.Y)) * 2;
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
            uhel = (float)Math.Acos(uhel) * 180 / (float)Math.PI;
            Console.WriteLine("velikost uhlu: " + uhel);
            try
            {
                g.TranslateTransform(projekceStred.X, projekceStred.Y);

                g.RotateTransform(uhel);
                g.TranslateTransform(-projekceStred.X, -projekceStred.Y);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(uhel);
            }
            g.DrawArc(Pens.Black, projekceStred.X - width / 2, projekceStred.Y - height / 2, width, height, startAngle, sweepAngle);
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

        public void vykresliSeSBarvou(Vektor vektorX, Vektor vektorY, Vektor vektorPosun, Nakresna n, Pen b)
        {
            System.Drawing.Graphics g = n.getG();

            Console.WriteLine("top: " + top.projekceDo2D(vektorX, vektorY)[0] + " " + top.projekceDo2D(vektorX, vektorY)[1]);
            Console.WriteLine("right: " + right.projekceDo2D(vektorX, vektorY)[0] + " " + right.projekceDo2D(vektorX, vektorY)[1]);
            Console.WriteLine("stred: " + stred.projekceDo2D(vektorX, vektorY)[0] + " " + stred.projekceDo2D(vektorX, vektorY)[1]);
            PointF projekceTop = new PointF(top.projekceDo2D(vektorX, vektorY)[0] + vektorPosun.getSouradnice()[0], top.projekceDo2D(vektorX, vektorY)[1] + vektorPosun.getSouradnice()[1]);
            PointF projekceRight = new PointF(right.projekceDo2D(vektorX, vektorY)[0] + vektorPosun.getSouradnice()[0], right.projekceDo2D(vektorX, vektorY)[1] + vektorPosun.getSouradnice()[1]);
            PointF projekceStred = new PointF(stred.projekceDo2D(vektorX, vektorY)[0] + vektorPosun.getSouradnice()[0], stred.projekceDo2D(vektorX, vektorY)[1] + vektorPosun.getSouradnice()[1]);
            float width = (float)Math.Sqrt((projekceRight.X - projekceStred.X) * (projekceRight.X - projekceStred.X) + (projekceRight.Y - projekceStred.Y) * (projekceRight.Y - projekceStred.Y)) * 2;
            float height = (float)Math.Sqrt((projekceTop.X - projekceStred.X) * (projekceTop.X - projekceStred.X) + (projekceTop.Y - projekceStred.Y) * (projekceTop.Y - projekceStred.Y)) * 2;
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
            uhel = (float)Math.Acos(uhel) * 180 / (float)Math.PI;
            Console.WriteLine("velikost uhlu: " + uhel);
            try
            {
                g.TranslateTransform(projekceStred.X, projekceStred.Y);

                g.RotateTransform(uhel);
                g.TranslateTransform(-projekceStred.X, -projekceStred.Y);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(uhel);
            }
            g.DrawArc(b, projekceStred.X - width / 2, projekceStred.Y - height / 2, width, height, startAngle, sweepAngle);
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
    }
}
