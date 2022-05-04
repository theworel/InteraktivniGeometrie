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

        public string getName()
        {
            return this.name;
        }

        public Bod2D(float v1, float v2, string name)
        {
            this.souradniceX = v1;
            this.souradniceY = v2;
            this.name = name;
            this.nameVisible = true;
        }

        public Bod2D(float x, float y)
        {
            this.souradniceX = x;
            this.souradniceY = y;
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
    }
}
