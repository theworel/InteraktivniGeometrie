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

        public Bod2D(int x, int y)
        {
            this.souradniceX = x;
            this.souradniceY = y;
        }
        public float[] getSouradnice()
        {
            return new float[] { souradniceX, souradniceY };
        }

        public float[] projekceDo2D(float[] vektorX, float[] vektorY)
        {
            float noveX = souradniceX * vektorX[0] + souradniceY * vektorY[0];
            float noveY = souradniceX * vektorX[1] + souradniceY * vektorY[1];
            return new float[] { noveX, noveY };
        }

        public float[] projekceDo3D(float[] vektorX, float[] vektorY, float[] vektorZ)
        {
            throw new NotImplementedException();
        }
    }
}
