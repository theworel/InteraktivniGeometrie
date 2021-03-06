using System;
using System.Runtime.Serialization;
using System.Windows.Forms;
using static System.Drawing.Graphics;
using System.Drawing;
using InteraktivniGeometrie.Tvary;

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
        private Bod selected;
        private ComboBox comboBoxBody;

        public Graphics getG()
        {
            return g;
        }

        public void pridejEliptickyOblouk(string jmeno, string[] jmenaBodu)
        {
            Bod stred = najdiBodPodleJmena(jmenaBodu[0]);
            Bod k = najdiBodPodleJmena(jmenaBodu[3]);
            Bod z = najdiBodPodleJmena(jmenaBodu[2]);
            Bod dalsi = najdiBodPodleJmena(jmenaBodu[1]);

            this.prostor.pridejTvar(new EliptickyOblouk(stred, dalsi, z, k, new Vektor2D(0, 1), jmeno));
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

        public Nakresna(Panel p, ComboBox cb, int dimenze)
        {
            this.panel = p;
            this.vektorX = new Vektor2D (1, 0);
            this.vektorY = new Vektor2D ( 0, 1 );
            this.vektorPosun = new Vektor2D ( panel.Width/2, panel.Height/2);
            otoceni = 0;
            g = panel.CreateGraphics();
            prostor = new Prostor2D();
            this.dimenze = dimenze;
            this.comboBoxBody = cb;
            

        }
       

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
            if (selected != null)
            {
                if (b.getName() == selected.getName())
                    g.DrawEllipse(System.Drawing.Pens.Red, pozice[0] - 5 + vektorPosun.getSouradnice()[0], pozice[1] - 5 + vektorPosun.getSouradnice()[1], 10, 10);
                else
                    g.DrawEllipse(System.Drawing.Pens.Black, pozice[0] - 5 + vektorPosun.getSouradnice()[0], pozice[1] - 5 + vektorPosun.getSouradnice()[1], 10, 10);
            }
            else
            {
                g.DrawEllipse(System.Drawing.Pens.Black, pozice[0] - 5 + vektorPosun.getSouradnice()[0], pozice[1] - 5 + vektorPosun.getSouradnice()[1], 10, 10);
            }
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
            foreach (Bod p in this.prostor.vsechnyBody())
            {
                if (p.getName().Equals(b.getName()))
                {
                    MessageBox.Show("Bod s tímto jménem už existuje");
                    return;
                }
            }
            
            prostor.pridejBod(b);

            comboBoxBody.Items.Add(b.getName());
        }

        public void pridejCaru(string jmeno, string[] jmenaBodu)
        {
            Bod[] bodyNaCare = new Bod[jmenaBodu.Length];
            for(int i =0; i<jmenaBodu.Length; i++)
            {
                try
                {
                    bodyNaCare[i] = najdiBodPodleJmena(jmenaBodu[i]);
                }catch(BodNeexistujeException e)
                {
                    MessageBox.Show("Neplatné jméno bodu");
                    return;
                }
            }
            this.prostor.pridejTvar(new PrimaCara(jmeno, bodyNaCare));
        }

        public void pridejTvar(string jmeno, string[] jmenaBodu)
        {
            Bod[] bodyTvaru = new Bod[jmenaBodu.Length];
            for (int i = 0; i < jmenaBodu.Length; i++)
            {
                try
                {
                    bodyTvaru[i] = najdiBodPodleJmena(jmenaBodu[i]);
                }catch(BodNeexistujeException e)
                {
                    MessageBox.Show("Neplatné jméno bodu");
                    return;
                }
            }

            this.prostor.pridejTvar(new Mnohouhelnik(jmeno, bodyTvaru));
        }

        public void pridejKruznici(string jmeno, string[] jmenaBodu)
        {
            this.prostor.pridejTvar(new Kruznice(najdiBodPodleJmena(jmenaBodu[0]), najdiBodPodleJmena(jmenaBodu[1]), najdiBodPodleJmena(jmenaBodu[2]), jmeno));
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

        public string[] getJmenaVsechBodu()
        {

            string[] ret = new string[this.prostor.vsechnyBody().Length];
            for(int i=0; i<ret.Length; i++)
            {
                ret[i] = this.prostor.vsechnyBody()[i].getName();
            }
            return ret;
        }

        public void vyberBod(string jmeno)
        {
            try
            {
                selected = this.najdiBodPodleJmena(jmeno);
                Console.WriteLine("vybrán bod " + jmeno);
                this.VykresliSe();
            }catch(BodNeexistujeException e){
                Console.WriteLine("Neplatné jméno bodu: " + jmeno);
            }
        }

        public void posunVybranyBod(float X, float Y)
        {
            if (selected != null)
            {

                //(selected.1 + ?.1)*vX.1 + (selected.2 + ?.2)*vY.1 = X + selected.1*vX.1 + selected.2*vY.1 
                //(selected.1 + ?.1)*vX.2 + (selected.2 + ?.2)*vY.2 = Y + selected.1*vX.2 + selected.2*vY.2 
                //?.1*vX.1 + ?.2*vY.1 = X
                //?.1*vX.2 + ?.2*vY.2 = Y

                float[] prvniRadek = new float[] { vektorX.getSouradnice()[0], vektorY.getSouradnice()[0], X };
                float[] druhyRadek = new float[] { vektorX.getSouradnice()[1], vektorY.getSouradnice()[1], Y};
                try
                {
                    float pomer = vektorX.getSouradnice()[1] / vektorX.getSouradnice()[0];
                    for (int i = 0; i < 3; i++)
                    {
                        druhyRadek[i] = druhyRadek[i] - prvniRadek[i] * pomer;
                    }

                    float posunutiY = druhyRadek[2] / druhyRadek[1];
                    float posunutiX = (prvniRadek[2] - posunutiY * prvniRadek[1]) / prvniRadek[0];
                    selected.posun(new Vektor2D(posunutiX, posunutiY));
                }
                catch(DivideByZeroException e)
                {
                    float posunutiX = prvniRadek[2] / prvniRadek[1];
                    float posunutiY = (druhyRadek[2] - posunutiX * druhyRadek[1]) / druhyRadek[0];
                    selected.posun(new Vektor2D(posunutiX, posunutiY));
                }

                
                
            }
            //selected.posun(vektorX.skaluj(X).pricti(vektorY.skaluj(Y)));
            Console.WriteLine("X: " + selected.projekceDo2D(vektorX, vektorY)[0] + " Y: " + selected.projekceDo2D(vektorX,vektorY)[1]);
            this.VykresliSe();
        }
        
    }

    
}