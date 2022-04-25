using System;
using System.Runtime.Serialization;
using System.Windows.Forms;
using static System.Drawing.Graphics;
using System.Drawing;
namespace InteraktivniGeometrie
{
    
    public class Nakresna
    {
        private Panel panel;
        private static System.Drawing.Graphics g;
        private float[] vektorX;
        private float[] vektorY;
        private float[] vektorPosun;
        private float otoceni;
        private Prostor prostor;
        
        public Graphics getG()
        {
            return g;
        }
        public Nakresna(Panel p, int dimenze)
        {
            this.panel = p;
            this.vektorX = new float[] { 1, 0 };
            this.vektorY = new float[] { 0, 1 };
            this.vektorPosun = new float[] { panel.Width/2, panel.Height/2};
            otoceni = 0;
            g = panel.CreateGraphics();
            prostor = new Prostor2D();
            

        }
        public void nakresliCaru(PrimaCara u)
        {

            /*float[] poziceJmena = new float[] { u.klicoveBody()[0].projekceDo2D(vektorX, vektorY)[0] + u.klicoveBody()[u.klicoveBody().Length - 1].projekceDo2D(vektorX, vektorY)[0], u.klicoveBody()[0].projekceDo2D(vektorX, vektorY)[1] + u.klicoveBody()[u.klicoveBody().Length - 1].projekceDo2D(vektorX, vektorY)[1]+5 };
            for (int i = 0; i< u.klicoveBody().Length-1; i++)
            {
                nakresliUsecku(u.klicoveBody()[i], u.klicoveBody()[i + 1]);
            }

            g.DrawString(u.getName(), SystemFonts.DefaultFont, Brushes.Black, poziceJmena[0], poziceJmena[1]);*/
            float[,] vektory = new float[2, 2];
            vektory[0,0] = vektorX[0];
            vektory[0, 1] = vektorX[1];
            vektory[1, 0] = vektorY[0];
            vektory[1, 1] = vektorY[1];
            float[] poziceJmena;
            u.vykresliSe(vektory, this, out poziceJmena);

            g.DrawString(u.getName(), SystemFonts.DefaultFont, Brushes.Black, poziceJmena[0] + vektorPosun[0], poziceJmena[1] + vektorPosun[1]);
        }

        public void nakresliUsecku(Bod a, Bod b)
        {
            float[] poziceA = a.projekceDo2D(vektorX, vektorY);
            float[] poziceB = b.projekceDo2D(vektorX, vektorY);

            g.DrawLine(System.Drawing.Pens.Black, poziceA[0] + vektorPosun[0], poziceA[1] + vektorPosun[1] , poziceB[0] + vektorPosun[0] , poziceB[1] + vektorPosun[1]);

        }

        public void nakresliBod(Bod b)
        {
            float[] pozice = b.projekceDo2D(vektorX, vektorY);

            g.DrawEllipse(System.Drawing.Pens.Black, pozice[0] - 5 +vektorPosun[0], pozice[1] - 5+vektorPosun[1], 10, 10);
            g.DrawString(b.getName(), System.Drawing.SystemFonts.DefaultFont, System.Drawing.Brushes.Black, pozice[0] + 5+vektorPosun[0], pozice[1] + 5+vektorPosun[1]);
        }

        public void VykresliSe()
        {
            panel.Refresh();
            foreach (Bod b in prostor.vsechnyBody())
            {
                nakresliBod(b);
            }

            foreach(Tvar t in prostor.vsechnyTvary()){
                float[,] vektory = new float[2, 2];
                vektory[0, 0] = vektorX[0];
                vektory[0, 1] = vektorX[1];
                vektory[1, 0] = vektorY[0];
                vektory[1, 1] = vektorY[1];
                float[] poziceJmena = t.poziceJmena(vektory);
                foreach (Cara c in t.klicoveCary())
                {
                    
                    
                    c.vykresliSe(vektory,this);
                    //Console.WriteLine("jmeno: " + c.getName());
                    
                }
                Console.WriteLine("pozice jmena: " + poziceJmena[0] + " " + poziceJmena[1]);
                g.DrawString(t.getName(), System.Drawing.SystemFonts.DefaultFont, System.Drawing.Brushes.Black, poziceJmena[0]+vektorPosun[0], poziceJmena[1]+vektorPosun[1]);

            }

        }

        public Bod najdiBodPodleJmena(string name)
        {
            foreach(Bod b in this.prostor.vsechnyBody())
            {
                if (b.getName().Equals(name)){
                    return b;
                }
            }

            throw new BodNeexistujeException();
        }

        public void pridejBod(Bod b)
        {
            prostor.pridejBod(b);
        }

        public void pridejCaru(string jmeno, string[] jmenaBodu)
        {
            Bod[] bodyNaCare = new Bod[jmenaBodu.Length];
            for(int i =0; i<jmenaBodu.Length; i++)
            {
                bodyNaCare[i] = najdiBodPodleJmena(jmenaBodu[i]);
            }
            this.prostor.pridejCaru(new PrimaCara(jmeno, bodyNaCare));
        }

        public void pridejTvar(string jmeno, string[] jmenaBodu)
        {
            Bod[] bodyTvaru = new Bod[jmenaBodu.Length];
            for (int i = 0; i < jmenaBodu.Length; i++)
            {
                bodyTvaru[i] = najdiBodPodleJmena(jmenaBodu[i]);
            }

            this.prostor.pridejTvar(new Mnohouhelnik(jmeno, bodyTvaru));
        }

        public void posun(float[] p)
        {
            this.vektorPosun[0] += p[0];
            this.vektorPosun[1] += p[1];
        }

        public void otoc(double uhel)
        {
            float[] novyVektorX = new float[] { vektorX[0] * (float)Math.Cos(uhel) - vektorX[1] * (float)Math.Sin(uhel) , vektorX[0] * (float)Math.Sin(uhel) + vektorX[1] * (float)Math.Cos(uhel) };
            float[] novyVektorY = new float[] { vektorY[0] * (float)Math.Cos(uhel) - vektorY[1] * (float)Math.Sin(uhel), vektorY[0] * (float)Math.Sin(uhel) + vektorY[1] * (float)Math.Cos(uhel) };
            this.vektorX = novyVektorX;
            this.vektorY = novyVektorY;
        }
        
    }

    
}