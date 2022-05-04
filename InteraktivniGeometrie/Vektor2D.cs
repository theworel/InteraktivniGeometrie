using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteraktivniGeometrie
{
    class Vektor2D : Vektor
    {
        public Vektor2D(Bod pocatek, Bod konec)
        {
            this.v1 = konec.getSouradnice()[0] - pocatek.getSouradnice()[0];
            this.v2 = konec.getSouradnice()[1] - pocatek.getSouradnice()[1];
        }

        public Vektor2D(float v1, float v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
        private float v1, v2;
        public float getDelka()
        {
            return (float)Math.Sqrt(v1 * v1 + v2 * v2);
        }

        public Bod posun(Bod posouvany)
        {
            return new Bod2D(posouvany.getSouradnice()[0], posouvany.getSouradnice()[1], "");
        }

        public Vektor pricti(Vektor druhy)
        {
            return new Vektor2D(v1 + druhy.getSouradnice()[0], v2 + druhy.getSouradnice()[1]);
        }

        public Vektor odecti(Vektor druhy)
        {
            return new Vektor2D(v1 - druhy.getSouradnice()[0], v2 - druhy.getSouradnice()[1]);
        }

        public Vektor skaluj(float alpha)
        {
            return new Vektor2D(this.v1 * alpha, this.v2 * alpha);
        }

        public Vektor projekceNa(Vektor druhy)
        {
            return druhy.skaluj(this.skalarniSoucin(druhy) / druhy.skalarniSoucin(druhy));
        }

        public Vektor nakolmiK(Vektor druhy)
        {
            return this.odecti(this.projekceNa(druhy));
        }

        public float skalarniSoucin(Vektor druhy)
        {
            return (v1*druhy.getSouradnice()[0] + v2*druhy.getSouradnice()[1]);
        }

        public float[] getSouradnice()
        {
           return new float[] { v1, v2 };
        }

        public Bod2D prusecikS(Vektor druhy, Bod2D pocatek1, Bod2D pocatek2)
        {
            /*soustava rovnic
             pocatek1.1 + v1*a = pocatek2.1 +druhy.1*b
             pocatek1.2 + v2*a = pocatek2.2 + druhy.2*b

            p1.1-p2.1 = v1*a + u1*b
            p1.2-p2.2 = v2*a + u2*b
             
             */

            float[] prvniRadek = new float[] { v1, druhy.getSouradnice()[0], pocatek1.getSouradnice()[0] - pocatek2.getSouradnice()[0] };
            float[] druhyRadek = new float[] { v2, druhy.getSouradnice()[1], pocatek1.getSouradnice()[1] - pocatek2.getSouradnice()[1] };

            float pomer = v2 / v1;
            for(int i=0; i<3; i++)
                druhyRadek[0] = druhyRadek[0] - pomer * prvniRadek[0];
            float b = druhyRadek[2] / druhyRadek[1];

            float a = (prvniRadek[2] - b * prvniRadek[1]) / prvniRadek[0];

            return (Bod2D) druhy.skaluj(b).posun(pocatek2);

        }

        public Bod prusecikS(Vektor druhy, Bod pocatek1, Bod pocatek2)
        {

            float[] prvniRadek = new float[] { v1, druhy.getSouradnice()[0], pocatek1.getSouradnice()[0] - pocatek2.getSouradnice()[0] };
            float[] druhyRadek = new float[] { v2, druhy.getSouradnice()[1], pocatek1.getSouradnice()[1] - pocatek2.getSouradnice()[1] };

            float pomer = v2 / v1;
            for (int i = 0; i < 3; i++)
                druhyRadek[0] = druhyRadek[0] - pomer * prvniRadek[0];
            float b = druhyRadek[2] / druhyRadek[1];

            float a = (prvniRadek[2] - b * prvniRadek[1]) / prvniRadek[0];

            return (Bod2D)druhy.skaluj(b).posun(pocatek2);
        }

        public float getUhel(Vektor druhy)
        {
            return (float) Math.Acos((double) (skalarniSoucin(druhy) / this.getDelka() / druhy.getDelka()));
        }

        public void otoc(Vektor druhyVektor, float uhel)//druhyVektor spolecne s otacenym vektorem definuji rovinu, ve které vektor otacime, pro 2D geometrii neni potreba
        {
            float newv1 = (float)( this.v1 * Math.Cos(uhel) - this.v2 * Math.Sin(uhel));
            float newv2 = (float)(this.v1 * Math.Sin(uhel) + this.v2 * Math.Cos(uhel));

            this.v1 = newv1;
            this.v2 = newv2;
        }
    }
}
