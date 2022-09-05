using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace InteraktivniGeometrie
{
    class Bod2D : Bod
    {
        private float souradniceX;
        private float souradniceY;
        private string name;
        private bool nameVisible;
        private bool prusecik;
        

        public string getName()
        {
            return this.name;
        }

        public Bod2D(float v1, float v2, bool prusecik) : this(v1, v2)
        {
            this.prusecik = prusecik;
        }

        public bool jePrusecik()
        {
            return this.prusecik;
        }
        public Bod2D(float v1, float v2, string name)
        {
            this.souradniceX = v1;
            this.souradniceY = v2;
            this.name = name;
            this.nameVisible = true;
            prusecik = false;
        }

        public Bod2D(float x, float y)
        {
            this.souradniceX = x;
            this.souradniceY = y;
            prusecik = false;
        }

        public Bod2D(float v1, float v2, bool prusecik, int pocetPruseciku) : this(v1, v2, prusecik)
        {
            this.name = "prusecik " + pocetPruseciku;
        }

        public float[] getSouradnice()
        {
            return new float[] { souradniceX, souradniceY };
        }

        public float[] projekceDo2D(Vektor vektorX, Vektor vektorY)
        {
            float noveX = souradniceX * vektorX.getSouradnice()[0] + souradniceY * vektorY.getSouradnice()[0];
            float noveY = souradniceX * vektorX.getSouradnice()[1] + souradniceY * vektorY.getSouradnice()[1];
            return new float[] { noveX, noveY };
        }

        public float[] projekceDo3D(Vektor vektorX, Vektor vektorY, Vektor vektorZ)
        {
            throw new NotImplementedException();
        }

        public float vzdalenostOd(Bod b)
        {
            if (typeof(Bod2D).IsInstanceOfType(b))
            {
                return (float)Math.Sqrt((souradniceX - b.getSouradnice()[0]) * (souradniceX - b.getSouradnice()[0]) + (souradniceY - b.getSouradnice()[1]) * (souradniceY - b.getSouradnice()[1]));
            }

            else throw new NesouhlasneDimenzeException();
        }

        public Bod stredUsecky(Bod druhy)
        {
            return new Bod2D(souradniceX / 2 + druhy.getSouradnice()[0] / 2, souradniceY / 2 + druhy.getSouradnice()[1] / 2);
        }

        public Vektor vektorNaBod(Bod konec)
        {
            return new Vektor2D(this, konec);
        }

        public void posun(Vektor vPosun)
        {
            this.souradniceX += vPosun.getSouradnice()[0];
            this.souradniceY += vPosun.getSouradnice()[1];
        }

        public bool jeStejnyJako(Bod druhy)
        {
            return (this.vektorNaBod(druhy).getDelka() < 0.01F);
        }

        public Bod projekceNaPrimku(Bod pocatek, Vektor vektorX)
        {
            Vektor v = pocatek.vektorNaBod(this);
            Vektor smer = v.nakolmiK(vektorX);
            Bod projekce = smer.prusecikS(vektorX, this, pocatek);
            return projekce;
            
        }
    }
}
