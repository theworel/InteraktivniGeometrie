using System;
using System.Runtime.Serialization;
using System.Windows.Forms;
using static System.Drawing.Graphics;
using System.Drawing;
using InteraktivniGeometrie.Tvary;
using System.Collections.Generic;

namespace InteraktivniGeometrie
{
    /**
     * Třída, která tvoří rozhraní mezi uživatelem a vnitřní implmentací prostoru.
     * jejím úkolem je zobrazovat konstrukci v prostoru na obrazovku a provádět překlad mezi uživatelským vstupem (z textového vstupu i z UI) a vnitřní implementací geometrické konstrukce
    **/
    public class Nakresna
    {
        /*
         * panel, na který je kresleno, hlavní grafický výstup celého programu
         * **/
        private Panel panel;
        private static System.Drawing.Graphics g;
        /**
         * vektory určující otočení a posunutí zobrazované plochy
         * **/
        private Vektor vektorX;
        private Vektor vektorY;
        private Vektor vektorPosun;

        /**
         * Prostor obsahující geometrickou konstrukci tak, jak ji vidí program
         * **/
        private Prostor prostor;
        /**
         * Počet dimenzí, v současnosti musí být 2
         * ¨**/
        private int dimenze;

        /**
         * Zvolený bod pro posouvání či mazání uživatelem
         * **/
        private Bod selected;
        private Tvar selectedTvar;

        /**
         * Comboboxy pro změnu vybraného tvaru/bodu
         * **/
        private ComboBox comboBoxBody;
        private ComboBox comboBoxTvary;
        

        /**
         * Seznam tvaru, jejichž průsečíky mají být zobrazeny
         * **/
        private List<Tuple<String, String>> bodySPruseciky;
        

        public Graphics getG()
        {
            return g;
        }

        public string jmenoVybraneho()
        {
            return this.selected.getName();
        }

        
        internal void nakresliPruseciky(string v1, string v2)
        {
            foreach (Bod b in prostor.najdiPrusecikyTvaru(najdiTvarPodleJmena(v1), najdiTvarPodleJmena(v2))){
                nakresliBod(b);
            }
        }

        /**
         * Funkce vracející textový zápis konstrukce takový, aby z něj celá konstrukce mohla být rekonstruována
         * **/
        public string[] getHistory()
        {
            List<string> ret = new List<string>();

            foreach(Bod b in this.prostor.vsechnyVolneBody())
            {
                ret.Add("PridejBod " + b.getSouradnice()[0] + " " + b.getSouradnice()[1] + " " + b.getName());
            }

            foreach(Tvar t in this.prostor.vsechnyTvary())
            {
                ret.Add(t.getCommand());
            }

            foreach(Tuple<string, string> t in this.bodySPruseciky)
            {
                ret.Add("PridejPruseciky " + t.Item1 + " " + t.Item2);
            }
            return ret.ToArray();
        }

        public void pridejPruseciky(string prvniJmeno, string druheJmeno)
        {
            /*Tvar t1, t2;
            t1 = null;
            t2 = null;
            foreach (Tvar t in this.prostor.vsechnyTvary()){
                if (t.getName().Equals(prvniJmeno))
                    t1 = t;
                if (t.getName().Equals(druheJmeno))
                    t2 = t;
            }

            if(t1==null || t2 == null)
            {
                MessageBox.Show("Tvar s tímto jménem neexistuje");
                return;
            }*/
            this.bodySPruseciky.Add(new Tuple<string, string>(prvniJmeno, druheJmeno));
            //prostor.pridejPrusecikyTvaru(t1, t2);
        }
       
        public Vektor[] getVektory()
        {
            return new Vektor[] { vektorX, vektorY, vektorPosun };
        }

        public void pridejEliptickyOblouk(string jmeno, string[] args)
        {
            if (args.Length == 4)
            {
                float sweepAngle;
                if (float.TryParse(args[3], out sweepAngle)){
                    Bod ohnisko1 = najdiBodPodleJmena(args[0]);
                    Bod ohnisko2 = najdiBodPodleJmena(args[1]);
                    Bod stredd = najdiBodPodleJmena(args[2]);
                    this.prostor.pridejTvar(new EliptickyObloukOhniskovy(ohnisko1, ohnisko2, stredd, sweepAngle, new Vektor2D(0, 1), jmeno));
                }
                Bod stred = najdiBodPodleJmena(args[0]);
                Bod k = najdiBodPodleJmena(args[3]);
                Bod z = najdiBodPodleJmena(args[2]);
                Bod dalsi = najdiBodPodleJmena(args[1]);

                this.prostor.pridejTvar(new EliptickyOblouk(stred, dalsi, z, k, new Vektor2D(0, 1), jmeno));
            }
            if(args.Length == 3)
            {
                Bod ohnisko1 = najdiBodPodleJmena(args[0]);
                Bod ohnisko2 = najdiBodPodleJmena(args[1]);
                Bod dalsi = najdiBodPodleJmena(args[2]);

                this.prostor.pridejTvar(new EliptickyObloukOhniskovy(ohnisko1, ohnisko2, dalsi, 360, new Vektor2D(0, 1), jmeno));
            }
        }

       

        public Nakresna(Panel p, ComboBox cbBody, ComboBox cbTvary, int dimenze)
        {
            this.panel = p;
            this.vektorX = new Vektor2D (1, 0);
            this.vektorY = new Vektor2D ( 0, 1 );
            this.vektorPosun = new Vektor2D ( panel.Width/2, panel.Height/2);
            
            g = panel.CreateGraphics();
            prostor = new Prostor2D();
            this.dimenze = dimenze;
            cbBody.Items.Clear();
            cbTvary.Items.Clear();
            this.comboBoxBody = cbBody;
            cbBody.Items.Add("");
            this.comboBoxTvary = cbTvary;
            cbTvary.Items.Add("");
            
            this.bodySPruseciky = new List<Tuple<string, string>>();

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

        public void nakresliBod(Bod b, string jmeno)
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
            g.DrawString(jmeno, System.Drawing.SystemFonts.DefaultFont, System.Drawing.Brushes.Black, pozice[0] + 5 + vektorPosun.getSouradnice()[0], pozice[1] + 5 + vektorPosun.getSouradnice()[1]);
        }

        /*internal void zapis(string command)
        {
           

        }*/

            /**
             * Aktualizuje komponentu panel tak, aby odpovídala konstrukci v Prostoru**/

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

                    if (!t.Equals(selectedTvar))
                        c.vykresliSe(vektorX, vektorY, vektorPosun, this);
                    else
                        c.vykresliSeSBarvou(vektorX, vektorY, vektorPosun, this, Pens.Red);
                   
                    
                }
                
                if(!t.Equals(selectedTvar))
                    g.DrawString(t.getName(), System.Drawing.SystemFonts.DefaultFont, System.Drawing.Brushes.Black, poziceJmena[0]+vektorPosun.getSouradnice()[0], poziceJmena[1]+vektorPosun.getSouradnice()[1]);
                else
                    g.DrawString(t.getName(), System.Drawing.SystemFonts.DefaultFont, System.Drawing.Brushes.Red, poziceJmena[0] + vektorPosun.getSouradnice()[0], poziceJmena[1] + vektorPosun.getSouradnice()[1]);
            }
            int i = 1;
            foreach(Tuple<string, string> t in this.bodySPruseciky)
            {
                foreach(Bod b in prostor.najdiPrusecikyTvaru(najdiTvarPodleJmena(t.Item1),najdiTvarPodleJmena(t.Item2))){
                    nakresliBod(b, "prusecik "+ i);
                    i++;
                    
                }
            }

        }

        /**
         * Přeloží jméno bodu na konkrétní instanci třídy Bod v Prostoru
         * **/
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

        
        /**
         * Přeloží jméno tvaru na konkrétní instanci tvaru v Prostoru
         * **/
        public Tvar najdiTvarPodleJmena(string name)
        {
            foreach(Tvar t in this.prostor.vsechnyTvary())
            {
                if (t.getName().Equals(name))
                {
                    return t;
                }
            }

            throw new TvarNeexistujeException();
        }

        /**
         * Přidá nový bod do prostoru
         * **/
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

        /**
         * Smaže bod se zadaným jménem z prostoru
         * **/
        public void odeberBod(string jmeno)
        {
            
            this.comboBoxBody.Items.Remove(jmeno);
            this.comboBoxTvary.Items.Clear();
            comboBoxTvary.Items.Add("");
            this.prostor.odeberBod(najdiBodPodleJmena(jmeno));
            foreach (Tvar t in prostor.vsechnyTvary())
            {
                comboBoxTvary.Items.Add(t.getName());
            }
            comboBoxBody.SelectedIndex = 0;
            
            this.VykresliSe();

        }

        /**
         * Smaže tvar s danným jménem z prostoru
         * **/

        public void odeberTvar(string jmeno)
        {
            this.prostor.odeberTvar(najdiTvarPodleJmena(jmeno));
            this.comboBoxTvary.Items.Remove(jmeno);
            comboBoxTvary.SelectedIndex = 0;
            this.VykresliSe();
        }

        /**
         * Přidá do prostoru tvar typu PrimaCara
         * **/
        public void pridejCaru(string jmeno, string[] jmenaBodu)
        {
            foreach (Tvar t in this.prostor.vsechnyTvary())
            {
                if (jmeno.Equals(t.getName()))
                {
                    MessageBox.Show("Tvar s tímto jménem už existuje");
                    return;
                }
            }
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
            comboBoxTvary.Items.Add(jmeno);
        }

        /**
         * Přidá do prostoru tvar typu Mnohoúhelník
         * **/

        public void pridejTvar(string jmeno, string[] jmenaBodu)
        {
            foreach (Tvar t in this.prostor.vsechnyTvary())
            {
                if (jmeno.Equals(t.getName()))
                {
                    MessageBox.Show("Tvar s tímto jménem už existuje");
                    return;
                }
            }
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
            comboBoxTvary.Items.Add(jmeno);
        }

        
        /**
         * Přidá do prostoru tvar typu Kruznice
         * **/
        public void pridejKruznici(string jmeno, string[] jmenaBodu)
        {
            foreach (Tvar t in this.prostor.vsechnyTvary())
            {
                if (jmeno.Equals(t.getName()))
                {
                    MessageBox.Show("Tvar s tímto jménem už existuje");
                    return;
                }
            }
            if(jmenaBodu.Length == 3)
                this.prostor.pridejTvar(new Kruznice(najdiBodPodleJmena(jmenaBodu[0]), najdiBodPodleJmena(jmenaBodu[1]), najdiBodPodleJmena(jmenaBodu[2]), jmeno));
            if (jmenaBodu.Length == 2)
                this.prostor.pridejTvar(new KruzniceStredova(najdiBodPodleJmena(jmenaBodu[0]), najdiBodPodleJmena(jmenaBodu[1]), new Vektor2D(0, 1), new Vektor2D(1,0), jmeno));
            comboBoxTvary.Items.Add(jmeno);
        }

        /**
         * Změní vektor posun, posune tedy vše zobrazené na panelu
         * **/
        public void posun(float[] p)
        {
            if (this.dimenze == 2)
            {
                this.vektorPosun = this.vektorPosun.pricti(new Vektor2D(p[0], p[1]));
            }
        }

        /**
         * Otočí vše zobrazené na panelu o daný úhel
         * **/
        public void otoc(float uhel)
        {
            this.vektorX.otoc(vektorY, uhel);
            this.vektorY.otoc(vektorX, uhel);
        }

        /**
         * Vrátí jména všech bodů v prostoru
         * */
        public string[] getJmenaVsechBodu()
        {

            string[] ret = new string[this.prostor.vsechnyBody().Length];
            for(int i=0; i<ret.Length; i++)
            {
                ret[i] = this.prostor.vsechnyBody()[i].getName();
            }
            return ret;
        }

        /**
         * Vrátí jména všech bodů, které nejsou prúsečíky**/
        public string[] getJmenaVsechVolnychBodu()
        {
            string[] ret = new string[this.prostor.vsechnyBody().Length];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = this.prostor.vsechnyVolneBody()[i].getName();
            }
            return ret;
        }

        /**
         * Vrátí jména všech tvarů v prostoru
         * **/
        public string[] getJmenaVsechTvaru()
        {
            string[] ret = new string[this.prostor.vsechnyTvary().Length];
            for(int i=0; i<ret.Length; i++)
            {
                ret[i] = this.prostor.vsechnyTvary()[i].getName();
            }
            return ret;
        }

        /**
         * Změní, který z bodů je vybraný pro ovládání uživatelem
         * **/
        public void vyberBod(string jmeno)
        {
            if (jmeno.Length == 0)
            {
                selected = null;
                this.VykresliSe();
                return;
            }
            try
            {
                selected = this.najdiBodPodleJmena(jmeno);
                
                this.VykresliSe();
            }catch(BodNeexistujeException e){
                MessageBox.Show("Neplatné jméno bodu: " + jmeno);
            }
        }

        /**
         * Změní, který z tvarů je vybraný pro ovládání uživatelem
         * **/
        public void vyberTvar(string jmeno)
        {
            if(jmeno.Length == 0)
            {
                selected = null;
                this.VykresliSe();
                return;
            }
            try
            {
                selectedTvar = this.najdiTvarPodleJmena(jmeno);
                this.VykresliSe();
            }
            catch (TvarNeexistujeException)
            {
                MessageBox.Show("Neplatne jméno bodu");
            }
        }

        /**
         * Posune vybraný bod (změní jeho souřadnice v Prostoru)
         * **/
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
           
            this.VykresliSe();
        }

        internal Tuple<string,string>[] getPruseciky()
        {
            return this.bodySPruseciky.ToArray();
        }

        internal void odeberPruseciky(Tuple<string, string> selectedItem)
        {
            this.bodySPruseciky.Remove(selectedItem);
        }
    }

    
}