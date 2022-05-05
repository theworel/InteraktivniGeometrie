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
        private Vektor vektorX;
        private Vektor vektorY;
        private Vektor vektorPosun;
        private float otoceni;
        private Prostor prostor;
        private int dimenze;
        public Graphics getG()
        {
            return g;
        }

        

        internal void pridejOblouky(string jmeno, string[] oblouky)
        {
            Cara[] obl = new Cara[oblouky.Length / 5];
            for(int i = 0; i<oblouky.Length ; i+=5)
            {
                obl[i / 3] = new Oblouk(najdiBodPodleJmena(oblouky[i]), najdiBodPodleJmena(oblouky[i + 1]), najdiBodPodleJmena(oblouky[i + 2]), float.Parse(oblouky[i + 3]), float.Parse(oblouky[i + 4]));
            }

            this.prostor.pridejTvar(new Oblouky_tvar(jmeno, obl));
        }

        public Nakresna(Panel p, int dimenze)
        {
            this.panel = p;
            this.vektorX = new Vektor2D (1, 0);
            this.vektorY = new Vektor2D ( 0, 1 );
            this.vektorPosun = new Vektor2D ( panel.Width/2, panel.Height/2);
            otoceni = 0;
            g = panel.CreateGraphics();
            prostor = new Prostor2D();
            this.dimenze = dimenze;
            

        }
        /*public void nakresliCaru(PrimaCara u)
        {

            float[] poziceJmena = new float[] { u.klicoveBody()[0].projekceDo2D(vektorX, vektorY)[0] + u.klicoveBody()[u.klicoveBody().Length - 1].projekceDo2D(vektorX, vektorY)[0], u.klicoveBody()[0].projekceDo2D(vektorX, vektorY)[1] + u.klicoveBody()[u.klicoveBody().Length - 1].projekceDo2D(vektorX, vektorY)[1]+5 };
            for (int i = 0; i< u.klicoveBody().Length-1; i++)
            {
                nakresliUsecku(u.klicoveBody()[i], u.klicoveBody()[i + 1]);
            }

            g.DrawString(u.getName(), SystemFonts.DefaultFont, Brushes.Black, poziceJmena[0], poziceJmena[1]);
            float[,] vektory = new float[2, 2];
            vektory[0,0] = vektorX[0];
            vektory[0, 1] = vektorX[1];
            vektory[1, 0] = vektorY[0];
            vektory[1, 1] = vektorY[1];
            float[] poziceJmena;
            u.vykresliSe(vektorX, vektorY, this, out poziceJmena);

            g.DrawString(u.getName(), SystemFonts.DefaultFont, Brushes.Black, poziceJmena[0] + vektorPosun[0], poziceJmena[1] + vektorPosun[1]);
        }*/

        public void nakresliUsecku(Usecka u)
        {
            /*float[] poziceA = a.projekceDo2D(vektorX, vektorY);
            float[] poziceB = b.projekceDo2D(vektorX, vektorY);

            g.DrawLine(System.Drawing.Pens.Black, poziceA[0] + vektorPosun[0], poziceA[1] + vektorPosun[1] , poziceB[0] + vektorPosun[0] , poziceB[1] + vektorPosun[1]);
            */
            float[,] vektory = new float[2, 2];
            
            u.vykresliSe(vektorX, vektorY, vektorPosun, this);
        }

        public void nakresliBod(Bod b)
        {
            float[] pozice = b.projekceDo2D(vektorX, vektorY);

            g.DrawEllipse(System.Drawing.Pens.Black, pozice[0] - 5 +vektorPosun.getSouradnice()[0], pozice[1] - 5+vektorPosun.getSouradnice()[1], 10, 10);
            g.DrawString(b.getName(), System.Drawing.SystemFonts.DefaultFont, System.Drawing.Brushes.Black, pozice[0] + 5+vektorPosun.getSouradnice()[0], pozice[1] + 5+vektorPosun.getSouradnice()[1]);
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
                
                float[] poziceJmena = t.poziceJmena(vektorX, vektorY);
                foreach (Cara c in t.klicoveCary())
                {
                    
                    
                    c.vykresliSe(vektorX, vektorY, vektorPosun,this);
                    //Console.WriteLine("jmeno: " + c.getName());
                    
                }
                Console.WriteLine("pozice jmena: " + poziceJmena[0] + " " + poziceJmena[1]);
                g.DrawString(t.getName(), System.Drawing.SystemFonts.DefaultFont, System.Drawing.Brushes.Black, poziceJmena[0]+vektorPosun.getSouradnice()[0], poziceJmena[1]+vektorPosun.getSouradnice()[1]);

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
            this.prostor.pridejTvar(new PrimaCara(jmeno, bodyNaCare));
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
            if (this.dimenze == 2)
            {
                this.vektorPosun = this.vektorPosun.pricti(new Vektor2D(p[0], p[1]));
            }
        }

        public void otoc(float uhel)
        {
            this.vektorX.otoc(vektorY, uhel);
            this.vektorY.otoc(vektorX, uhel);
        }
        
    }

    
}